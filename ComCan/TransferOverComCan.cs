using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using ML.Can;
using ML.DataExchange;
using ML.DataExchange.Interfaces;

namespace ComCan
{
    public class TransferOverComCan : IDataExchange
    {
        public TransferOverComCan()
        {
            Device = new ComCANIO();
            _codtDomainArray = new List<byte>();
        }
        public bool StartExchange(string strPort)
        {
            _portName = strPort;
            string ret = Device.OpenCAN(_portName, 50);
            if (ret != "No_Err")
            {
                MessageBox.Show(ret);
                return false;
            }
            Thread.Sleep(500);
            ReceiveThread = new Thread(ReceiveThreadMethod);
            //ReceiveThread.Priority = ThreadPriority.Highest;
            ReceiveThread.IsBackground = true;
            ReceiveThread.Start(); //New thread starts
            return true;
        }

        public bool GetParameter(ushort parameterId, byte subindex)
        {
            var dataList = new List<CanDriver.canmsg_t>();
            var msg = new CanDriver.canmsg_t();
            msg.flags = CanDriver.MSG_BOVR;
            msg.cob = 0;
            msg.id = 0x601; //rSdo + id=1
            msg.length = (short)CanDriver.DATALENGTH;
            msg.data = new byte[CanDriver.DATALENGTH];
            msg.data[0] = 0x40;//read data
            msg.data[1] = (byte)(parameterId);//id low
            msg.data[2] = (byte)(parameterId >> 8);//id high
            msg.data[3] = subindex;//subindex
            dataList.Add(msg);
            Device.SendData(dataList);
            return true;
        }

        public bool SetParameter(CanParameter canParameter)
        {
            var msg = new CanDriver.canmsg_t();
            msg.flags = CanDriver.MSG_BOVR;
            msg.cob = 0;
            msg.id = 0x601; //rSdo + id=1
            msg.length = (short)CanDriver.DATALENGTH;
            msg.data = new byte[CanDriver.DATALENGTH];
            msg.data[1] = (byte)(canParameter.ParameterId);//id low
            msg.data[2] = (byte)(canParameter.ParameterId >> 8);//id high
            msg.data[3] = 0x02;//subindex
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
            Device.SendData(new List<CanDriver.canmsg_t> { msg });
            return true;
        }

        public bool StopExchange()
        {
            Device.CloseCan();
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

        public event ReceiveHandler ReceiveEvent;

        public event Action<List<CanParameter>> ParameterReceive;

        private void ReceiveThreadMethod()
        {
            
            Parameters parameters;
            var param = new double[30];
            while (true)
            {

                try
                {
                    List<CanDriver.canmsg_t> msgRead = Device.ReceiveMsgBlock(MsgCount);
                    if (msgRead == null)
                    {
                        Device.OpenCAN(_portName, 50);
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

        private List<CanParameter> TryGetParameterValue(List<CanDriver.canmsg_t> msgData)
        {
            var canParameters = new List<CanParameter>();
            var msgList = msgData.Where(m => m.id == 0x581).ToList();
            if (msgList.Count != 0)
            {
                foreach (var canmsgT in msgList)
                {
                    if (canmsgT.data[0] == 0x43)//real32
                        canParameters.Add(new CanParameter
                        {
                            ParameterId = (ushort)(canmsgT.data[1] + (canmsgT.data[2] << 8)),
                            Data = new byte[] { canmsgT.data[4], canmsgT.data[5], canmsgT.data[6], canmsgT.data[7] }
                        });
                    else if (canmsgT.data[0] == 0x4B)//sint16
                        canParameters.Add(new CanParameter
                        {
                            ParameterId = (ushort)(canmsgT.data[1] + (canmsgT.data[2] << 8)),
                            Data = new byte[] { canmsgT.data[4], canmsgT.data[5] }
                        });
                    else if (canmsgT.data[0] == 0x47)//sint16
                        canParameters.Add(new CanParameter
                        {
                            ParameterId = (ushort)(canmsgT.data[1] + (canmsgT.data[2] << 8)),
                            Data = new byte[] { canmsgT.data[4], canmsgT.data[5], canmsgT.data[5] }
                        });
                    else if (canmsgT.data[0] == 0x41) //codtDomain
                    {
                        _codtDomainId = (ushort) (canmsgT.data[1] + (canmsgT.data[2] << 8));
                        var codtDomainThread = new Thread(GetSegment) {IsBackground = true};
                        codtDomainThread.Start(canmsgT);
                    }
                    else if (canmsgT.data[0] == 0x0 || canmsgT.data[0] == 0x10 || canmsgT.data[0] == 0x1D) // codtDomain Element
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
                        }
                    }
                }
            }
            return canParameters;
        }

        private void GetSegment(object canmsgT)
        {
            var msg = (CanDriver.canmsg_t)canmsgT;
            double byteNumber = msg.data[4];
            var _sendNumber = (int)Math.Ceiling((double)(byteNumber / 7));
            for (int i = 0; i < _sendNumber; i++)
            {
                if(i%2 == 0)
                    Device.SendData(new List<CanDriver.canmsg_t>{new CanDriver.canmsg_t
                    {
                        id = 0x601,length = 8,flags = CanDriver.MSG_BOVR,data = new byte[]
                        {
                            0x60,msg.data[1],msg.data[2],msg.data[3],0,0,0,0
                        }
                    }});
                else
                    Device.SendData(new List<CanDriver.canmsg_t>{new CanDriver.canmsg_t
                    {
                        id = 0x601,length = 8,flags = CanDriver.MSG_BOVR,data = new byte[]
                        {
                            0x70,msg.data[1],msg.data[2],msg.data[3],0,0,0,0
                        }
                    }});
                Thread.Sleep(200);
            }

        }

        private readonly ComCANIO Device;
        private Thread ReceiveThread;
        private const int MsgCount = 80;
        private string _portName;
        private List<byte> _codtDomainArray;
        private ushort _codtDomainId;
    }
}
