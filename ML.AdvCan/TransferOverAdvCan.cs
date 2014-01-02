using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ML.Can;
using ML.DataExchange;
using ML.DataExchange.Interfaces;

namespace ML.AdvCan
{
    public class TransferOverAdvCan : IDataExchange
    {
        public TransferOverAdvCan()
        {
            Device = new AdvCANIO();
        }

        public bool StartExchange(string strPort)
        {
            string ret = Device.OpenCAN(strPort, 50);
            if (ret != "No_Err")
                return false;
            ReceiveThread = new Thread(ReceiveThreadMethod);
            ReceiveThread.Priority = ThreadPriority.Highest;
            ReceiveThread.IsBackground = true;
            ReceiveThread.Start(); //New thread starts
            return true;
        }

        public bool StopExchange()
        {
            m_bRun = false;
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
            msg.data[2] = (byte)(parameterId>>8);//id high
            msg.data[3] = subindex;//subindex
            dataList.Add(msg);
            Device.SendData(dataList);
            Device.SendData(dataList);
            return true;
        }

        public bool GetSegment(ushort parameterId, byte subindex)
        {
            var dataList = new List<CanDriver.canmsg_t>();
            var msg = new CanDriver.canmsg_t();
            msg.flags = CanDriver.MSG_BOVR;
            msg.cob = 0;
            msg.id = 0x601; //rSdo + id=1
            msg.length = (short)CanDriver.DATALENGTH;
            msg.data = new byte[CanDriver.DATALENGTH];
            msg.data[0] = 0x60;//read segment
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

        public List<CanParameter> TryGetParameterValue(List<CanDriver.canmsg_t> msgData)
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
                            ParameterId = (ushort) (canmsgT.data[1] + (canmsgT.data[2] << 8)),
                            Data = new byte[] {canmsgT.data[4], canmsgT.data[5], canmsgT.data[6], canmsgT.data[7]}
                        });
                    else if(canmsgT.data[0] == 0x4B)//sint16
                        canParameters.Add(new CanParameter
                        {
                            ParameterId = (ushort)(canmsgT.data[1] + (canmsgT.data[2] << 8)),
                            Data = new byte[] { canmsgT.data[4], canmsgT.data[5]}
                        });
                    else if (canmsgT.data[0] == 0x47)//sint24
                        canParameters.Add(new CanParameter
                        {
                            ParameterId = (ushort)(canmsgT.data[1] + (canmsgT.data[2] << 8)),
                            Data = new byte[] { canmsgT.data[4], canmsgT.data[5], canmsgT.data[5] }
                        });
                    else if(canmsgT.data[0] == 0x41) //data segment
                        GetSegment((ushort) (canmsgT.data[1] + (canmsgT.data[2] << 8)), canmsgT.data[3]);
                }
            }
            return canParameters;
        }

        private void ReceiveThreadMethod()
        {
            m_bRun = true;
            while (m_bRun)
            {
                /**********************************************************************************************
                 *  NOTE: acCanRead usage
                 * 
                 *    DescriptionЈє
                 *       Users can use this interface to receive data from CAN port which was opened. 
                 *       One or more frames can be read each time.
                 * 
                 *    Parameters:
                 *       msgRead                 - managed buffer to read
                 *       nReadCount              - CAN frame number want to read each time
                 *       pulNumberofRead         - Real number of frames read from driver.
                 *    
                 *    In this example, we receive 100 CAN frames defined by 'nMsgCount' each time by default.             
                 *    If want to receive one or more frames each time, user can also change it as follows:
                 *    Firstly, open CAN port and pass the value of 'MsgNumberOfReadBuffer' and 'MsgNumberOfWriteBuffer'arguments.
                 *    About 'MsgNumberOfReadBuffer' and 'MsgNumberOfWriteBuffer', please see 'acCanPort' usage in this examples.
                 *    Secondly, define the msgRead according to the frame number user want to read each time.
                 *    Thirdly, define the value of 'nReadCount'according to the frame number user want to read each time.
                 *    In this examples, user can only change the value of 'nMsgCount' to change the count of frame want to receive each time. 
                /**********************************************************************************************/
                List<CanDriver.canmsg_t> msgRead = Device.ReceiveMsgBlock(nMsgCount);
                Parameters parameters;
                try
                {
                    if (msgRead.Count > 4)
                    {
                        parameters = CanParser.GetParameters(msgRead);
                        ReceiveEvent(parameters);
                        List<CanParameter> canParameters = TryGetParameterValue(msgRead);
                        if (canParameters.Count != 0)
                            ParameterReceive(canParameters);
                    }
                }
                catch (Exception exception)
                {
                    
                }
                
                Thread.Sleep(20);
            }
        }

        


        public event ReceiveHandler ReceiveEvent;

        public event Action<List<CanParameter>> ParameterReceive;

        private readonly AdvCANIO Device;
        private bool m_bRun;
        private bool syncflag;
        private int nMsgCount = 80;
        private Thread ReceiveThread;
        private ThreadStart ReceiveThreadSt;
    }
}
