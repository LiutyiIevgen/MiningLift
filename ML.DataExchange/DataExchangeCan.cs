using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ML.AdvCan;
using ML.Can;
using ML.Can.Interfaces;
using ML.DataExchange.Interfaces;
using ML.DataExchange.Model;

namespace ML.DataExchange
{
    public class DataExchangeCan : IDataExchange
    {
        public DataExchangeCan()
        {
            _codtDomainArray = new List<byte>();
        }

        public bool StartExchange(string strPort,int portSpeed, ICanIO device)
        {
            _portName = strPort;
            _portSpeed = portSpeed;
            _device = device;
            string ret = _device.OpenCAN(strPort, portSpeed);
            if (ret != "No_Err")
            {
                MessageBox.Show(ret);
                return false;
            }
            Thread.Sleep(200);
            ReceiveThread = new Thread(ReceiveThreadMethod);
            ReceiveThread.Priority = ThreadPriority.Highest;
            ReceiveThread.IsBackground = true;
            ReceiveThread.Start(); //New thread starts
            return true;
        }

        public bool StopExchange()
        {
            m_bRun = false;
            _device.CloseCan();
            try
            {
                if ((ReceiveThread.ThreadState & (ThreadState.Stopped | ThreadState.Unstarted)) == 0)
                {
                    ReceiveThread.Abort();
                    ReceiveThread.Join(); //Thread stops
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool GetParameter(ushort controllerId, ushort parameterId, byte subindex)
        {
            var dataList = new List<CanDriver.canmsg_t>();
            var msg = new CanDriver.canmsg_t();
            msg.flags = CanDriver.MSG_BOVR;
            msg.cob = 0;
            msg.id = (uint)(0x600 + controllerId); //rSdo + id=1
            msg.length = (short)CanDriver.DATALENGTH;
            msg.data = new byte[CanDriver.DATALENGTH];
            msg.data[0] = 0x40;//read data
            msg.data[1] = (byte)(parameterId);//id low
            msg.data[2] = (byte)(parameterId>>8);//id high
            msg.data[3] = subindex;//subindex
            dataList.Add(msg);
            _device.SendData(dataList);
            return true;
        }



        public bool SetParameter(ushort controllerId, CanParameter canParameter)
        {
            var msg = new CanDriver.canmsg_t();
            msg.flags = CanDriver.MSG_BOVR;
            msg.cob = 0;
            msg.id = (uint)(0x600 + controllerId); //rSdo + id=1
            msg.length = (short)CanDriver.DATALENGTH;
            msg.data = new byte[CanDriver.DATALENGTH];
            msg.data[1] = (byte)(canParameter.ParameterId);//id low
            msg.data[2] = (byte)(canParameter.ParameterId >> 8);//id high
            msg.data[3] = canParameter.ParameterSubIndex;//subindex
            if (canParameter.Data.Count() == 4)
            {
                msg.data[0] = 0x22; //write 4 byte e=1 s=0;
                msg.data[4] = canParameter.Data[0];
                msg.data[5] = canParameter.Data[1];
                msg.data[6] = canParameter.Data[2];
                msg.data[7] = canParameter.Data[3];
            }
            else if (canParameter.Data.Count() == 2)
            {
                msg.data[0] = 0x2A; //write 2 byte e=1 s=0;
                msg.data[4] = canParameter.Data[0];
                msg.data[5] = canParameter.Data[1];
            }
            else //codtDomain
            {
                _codtDomainThread = new Thread(SetSegment) { IsBackground = true };
                _codtDomainThread.Start(canParameter);
                return true;
            }
            _device.SendData(new List<CanDriver.canmsg_t> { msg });
            return true;
        }

        public event ReceiveHandler ReceiveEvent;

        public event Action<List<CanParameter>> ParameterReceive;

        private List<CanParameter> TryGetParameterValue(List<CanDriver.canmsg_t> msgData)
        {
            var canParameters = new List<CanParameter>();
            var msgList = msgData.Where(m => (m.id & 0xF80) == 0x580).ToList();
            if (msgList.Count != 0)
            {
                foreach (var canmsgT in msgList)
                {
                    if (canmsgT.data[0] == 0x43)//get real32
                        canParameters.Add(new CanParameter
                        {
                            ParameterId = (ushort)(canmsgT.data[1] + (canmsgT.data[2] << 8)),
                            Data = new byte[] { canmsgT.data[4], canmsgT.data[5], canmsgT.data[6], canmsgT.data[7] }
                        });
                    else if (canmsgT.data[0] == 0x4B)//get sint16
                        canParameters.Add(new CanParameter
                        {
                            ParameterId = (ushort)(canmsgT.data[1] + (canmsgT.data[2] << 8)),
                            Data = new byte[] { canmsgT.data[4], canmsgT.data[5] }
                        });
                    else if (canmsgT.data[0] == 0x47)//get sint24
                        canParameters.Add(new CanParameter
                        {
                            ParameterId = (ushort)(canmsgT.data[1] + (canmsgT.data[2] << 8)),
                            Data = new byte[] { canmsgT.data[4], canmsgT.data[5], canmsgT.data[6] }
                        });
                    else if (canmsgT.data[0] == 0x41) //get codtDomain
                    {
                        _codtDomainId = (ushort)(canmsgT.data[1] + (canmsgT.data[2] << 8));
                        _codtDomainThread = new Thread(GetSegment) { IsBackground = true };
                        _codtDomainThread.Start(canmsgT);
                    }
                    else if (canmsgT.data[0] == 0x0 || canmsgT.data[0] == 0x10 || canmsgT.data[0] == 0x1D) //get codtDomain block
                    {
                        _codtDomainArray.AddRange(new List<byte>
                        {
                            canmsgT.data[1],
                            canmsgT.data[2],
                            canmsgT.data[3],
                            canmsgT.data[4],
                            canmsgT.data[5],
                            canmsgT.data[6],
                            canmsgT.data[7]
                        });
                        if (canmsgT.data[0] == 0x1D) //last codtDomain Element
                        {
                            canParameters.Add(new CanParameter
                            {
                                ParameterId = _codtDomainId,
                                Data = _codtDomainArray.ToArray()
                            });
                            _codtDomainArray.Clear();
                        }
                    }
                    else if (canmsgT.data[0] == 0x60) //parameter was seted
                    {
                        if (_codtDomainThread != null)
                            if (_codtDomainThread.IsAlive)
                                continue;
                        canParameters.Add(new CanParameter
                        {
                            ParameterId = (ushort) (canmsgT.data[1] + (canmsgT.data[2] << 8)),
                            ParameterSubIndex = canmsgT.data[3]
                        });
                    }
                }
            }
            return canParameters;
        }

        private void ReceiveThreadMethod()
        {
            Parameters parameters;
            var param = new double[30];
            while (true)
            {

                try
                {
                    List<CanDriver.canmsg_t> msgRead = _device.ReceiveMsgBlock(MsgCount);
                    if (msgRead == null)
                    {
                        _device.OpenCAN(_portName, _portSpeed);
                        Thread.Sleep(5);
                        continue;              
                    }
                    parameters = CanParser.GetParameters(msgRead);
                    ReceiveEvent(parameters);
                    List<CanParameter> canParameters = TryGetParameterValue(msgRead);
                    if (canParameters.Count != 0)
                        ParameterReceive(canParameters);
                    Thread.Sleep(20);
                }
                catch(Exception)
                {
                    continue;
                }
            }
        }

        private void GetSegment(object canmsgT)
        {
            var msg = (CanDriver.canmsg_t)canmsgT;
            double byteNumber = msg.data[4];
            var _sendNumber = (int)Math.Ceiling((double)(byteNumber / 7));
            for (int i = 0; i < _sendNumber; i++)
            {
                if (i % 2 == 0)
                    _device.SendData(new List<CanDriver.canmsg_t>{new CanDriver.canmsg_t
                    {
                        id = 0x601,length = 8,flags = CanDriver.MSG_BOVR,data = new byte[]
                        {
                            0x60,msg.data[1],msg.data[2],msg.data[3],0,0,0,0
                        }
                    }});
                else
                    _device.SendData(new List<CanDriver.canmsg_t>{new CanDriver.canmsg_t
                    {
                        id = 0x601,length = 8,flags = CanDriver.MSG_BOVR,data = new byte[]
                        {
                            0x70,msg.data[1],msg.data[2],msg.data[3],0,0,0,0
                        }
                    }});
                Thread.Sleep(200);
            }
        }

        private void SetSegment(object parameter)
        {
            var canParameter = parameter as CanParameter;
            var msg = new CanDriver.canmsg_t();
            msg.flags = CanDriver.MSG_BOVR;
            msg.cob = 0;
            msg.id = 0x601; //rSdo + id=1
            msg.length = (short)CanDriver.DATALENGTH;
            msg.data = new byte[CanDriver.DATALENGTH];
            msg.data[0] = 0x20; //write segment e=0 s=0;
            msg.data[1] = (byte)(canParameter.ParameterId);//id low
            msg.data[2] = (byte)(canParameter.ParameterId >> 8);//id high
            msg.data[3] = canParameter.ParameterSubIndex;//subindex     
            msg.data[4] = (byte)canParameter.Data.Count();
            //Device.SendData(new List<CanDriver.canmsg_t> { msg });// start block
            Thread.Sleep(20);
            _device.SendData(new List<CanDriver.canmsg_t> { msg });// start block
            Thread.Sleep(200);
            double byteCount = canParameter.Data.Count();
            var _sendNumber = (int)Math.Ceiling((double)(byteCount / 7));
            int i = 0;
            while (i < _sendNumber)
            {
                var block = new byte[8];
                for (int j = 0; j < 7; j++)
                {
                    if (i * 7 + j >= canParameter.Data.Count())
                        block[j + 1] = 0;
                    else
                        block[j + 1] = canParameter.Data[i * 7 + j];
                }
                if (i == _sendNumber - 1)
                {
                    block[0] = 0x1D;
                    ParameterReceive(new List<CanParameter> //parameter was seted
                    {
                        new CanParameter
                        {
                            ParameterId = canParameter.ParameterId,
                            ParameterSubIndex = canParameter.ParameterSubIndex
                        }
                    });
                }
                else if (i%2 == 0)
                    block[0] = 0;
                else
                    block[0] = 0x10;
                _device.SendData(new List<CanDriver.canmsg_t>
                {
                    new CanDriver.canmsg_t
                    {
                        id = 0x601,
                        length = 8,
                        flags = CanDriver.MSG_BOVR,
                        data = block
                    }
                });
                i++;
                Thread.Sleep(170);
            }
        }

        private ICanIO _device;
        private bool m_bRun;
        private bool syncflag;
        private int MsgCount = 80;
        private string _portName;
        private int _portSpeed;
        private Thread ReceiveThread;
        private Thread _codtDomainThread;
        private List<byte> _codtDomainArray;
        private ushort _codtDomainId;
    }
}
