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
using ML.ConfigSettings.Services;
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



        public bool SetParameter(CanParameter canParameter)
        {
            var msg = new CanDriver.canmsg_t();
            msg.flags = CanDriver.MSG_BOVR;
            msg.cob = 0;
            msg.id = (uint)(0x600 + canParameter.ControllerId); //rSdo + id=1
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
            else if (canParameter.Data.Count() == 3)
            {
                msg.data[0] = 0x26; //write 3 byte e=1 s=0;
                msg.data[4] = canParameter.Data[0];
                msg.data[5] = canParameter.Data[1];
                msg.data[6] = canParameter.Data[2];
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
                    if ((canmsgT.data[0] & 0x73) == 0x43) // value block
                    {
                        var canParameter = new CanParameter()
                        {
                            ControllerId = (ushort) (canmsgT.id & 0x7F),
                            ParameterId = (ushort) (canmsgT.data[1] + (canmsgT.data[2] << 8)),
                            ParameterSubIndex = canmsgT.data[3]
                        };
                        int unusedBytes = (canmsgT.data[0] & 0x0C) >> 2;
                        canParameter.Data = new byte[4 - unusedBytes];
                        for (int j = 0; j < 4 - unusedBytes; j++)
                            canParameter.Data[j] = canmsgT.data[4 + j];
                        canParameters.Add(canParameter);
                    }
                    else if (canmsgT.data[0] == 0x41) //get codtDomain
                    {
                        _codtDomainId = (ushort)(canmsgT.data[1] + (canmsgT.data[2] << 8));
                        _codtDomainSubIndex = canmsgT.data[3];
                        _codtDomainThread = new Thread(GetSegment) { IsBackground = true };
                        _codtDomainThread.Start(canmsgT);
                    }
                    else if ((canmsgT.data[0]&0xE0) == 0) //get codtDomain block
                    {
                        int unusedBytes = (canmsgT.data[0] & 0x0E) >> 1;
                        for (int j = 0; j < 7 - unusedBytes; j++)
                            _codtDomainArray.Add(canmsgT.data[j+1]);
                        if ((canmsgT.data[0]&0x01) == 1)//last codtDomain Element
                        {
                            canParameters.Add(new CanParameter
                            {
                                ControllerId = (ushort)(canmsgT.id & 0x7F),
                                ParameterId = _codtDomainId,
                                ParameterSubIndex = _codtDomainSubIndex,
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
                            ControllerId = (ushort)(canmsgT.id&0x7F),
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
            var config = new MineConfig();
            var msgRead = new List<CanDriver.canmsg_t>();
            while (true)
            {

                try
                {

                    var msg = _device.ReceiveMsgBlock(MsgCount);
                    if (msg == null)
                    {
                        _device.OpenCAN(_portName, _portSpeed);
                        Thread.Sleep(50);
                        continue;
                    }
                    if (msg.Count == 0)
                    {
                        Thread.Sleep(5);
                        continue;
                    }
                    msgRead.AddRange(msg);
                    /*if (msgRead.Count < 7)
                        continue;*/
                    parameters = CanParser.GetParameters(msgRead, (byte) config.LeadingController); //путевая информация
                    if(parameters == null)
                        continue;
                    ReceiveEvent(parameters);
                    List<CanParameter> canParameters = TryGetParameterValue(msgRead); //параметры can
                    if (canParameters.Count != 0)
                        ParameterReceive(canParameters);
                    msgRead.Clear();
                    Thread.Sleep(12);
                }
                catch (Exception exception)
                {
                    
                }
            }
        }

        private void GetSegment(object canmsgT)//if codt domain send qeury for codtDomain blocks
        {
            var msg = (CanDriver.canmsg_t)canmsgT;
            double byteNumber = msg.data[4];
            var _sendNumber = (int)Math.Ceiling((double)(byteNumber / 7));
            for (int i = 0; i < _sendNumber; i++)
            {
                if (i % 2 == 0)
                    _device.SendData(new List<CanDriver.canmsg_t>{new CanDriver.canmsg_t
                    {
                        id = 0x600 + (msg.id&0x07F),length = 8,flags = CanDriver.MSG_BOVR,data = new byte[]
                        {
                            0x60,msg.data[1],msg.data[2],msg.data[3],0,0,0,0
                        }
                    }});
                else
                    _device.SendData(new List<CanDriver.canmsg_t>{new CanDriver.canmsg_t
                    {
                        id = 0x600 + (msg.id&0x07F),length = 8,flags = CanDriver.MSG_BOVR,data = new byte[]
                        {
                            0x70,msg.data[1],msg.data[2],msg.data[3],0,0,0,0
                        }
                    }});
                if(i!=_sendNumber - 1)
                    Thread.Sleep(200);
            }
        }

        private void SetSegment(object parameter)
        {
            //start block
            var canParameter = parameter as CanParameter;
            var msg = new CanDriver.canmsg_t();
            msg.flags = CanDriver.MSG_BOVR;
            msg.cob = 0;
            msg.id = (ushort)(0x600 + canParameter.ControllerId); //rSdo + id=1
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
            //send data
            int i = 0;
            while (i < _sendNumber)
            {
                var block = new byte[8];
                for (int j = 0; j < 7; j++)
                {
                    if (i * 7 + j >= canParameter.Data.Count()) //set last bute to 0
                        block[j + 1] = 0;
                    else
                        block[j + 1] = canParameter.Data[i * 7 + j];
                }
                if(i == _sendNumber - 1)//last block
                    block[0] = 0x1D;
                else if (i%2 == 0) //change count bit
                    block[0] = 0;
                else
                    block[0] = 0x10;
                _device.SendData(new List<CanDriver.canmsg_t>
                {
                    new CanDriver.canmsg_t
                    {
                        id = (ushort)(0x600 + canParameter.ControllerId),
                        length = 8,
                        flags = CanDriver.MSG_BOVR,
                        data = block
                    }
                });
                if (i == _sendNumber - 1) // if it was last block
                {
                    ParameterReceive(new List<CanParameter> //parameter was seted
                    {
                        new CanParameter
                        {
                            ControllerId = canParameter.ControllerId,
                            ParameterId = canParameter.ParameterId,
                            ParameterSubIndex = canParameter.ParameterSubIndex
                        }
                    });
                    return;
                }
                i++;
                Thread.Sleep(170);
            }
        }

        private ICanIO _device;
        private bool m_bRun;
        private bool syncflag;
        private int MsgCount = 180;
        private string _portName;
        private int _portSpeed;
        private Thread ReceiveThread;
        private Thread _codtDomainThread;
        private List<byte> _codtDomainArray;
        private ushort _codtDomainId;
        private byte _codtDomainSubIndex;
    }
}
