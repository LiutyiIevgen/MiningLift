using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ML.AdvCan;
using ML.AdvCan.CanDriver;
using ML.DataExchange.Interfaces;

namespace ML.DataExchange
{
    public class TransferOverCan : IDataExchange
    {
        public TransferOverCan()
        {
            Device = new AdvCANIO();
        }

        public bool StartExchange(string strPort)
        {
            string CanPortName;
            string StatusMsg = "";
            UInt16 BaudRateValue;
            int nRet = 0;
            uint WriteTimeOutValue;
            uint ReadTimeOutValue;
            CanPortName = strPort; //Get CAN port name
            /**********************************************************************************************
                 *  NOTE: acCanOpen Usage
                 * 
                 *	  Description:
                 *		 Open can port by name, and indicate the max send and receive Frame number each time.
                 * 
                 *    acCanOpen arguments:
                 *		  PortName			         - port name
                 *		  synchronization	         - TRUE, synchronization ; FALSE, asynchronous
                 *		  MsgNumberOfReadBuffer	   - The max frames number to read each time
                 *		  MsgNumberOfWriteBuffer	- The max frames number to write each time
                 * 
                 *    When open port, user must pass the value of 'MsgNumberOfReadBuffer' and 'MsgNumberOfWriteBuffer' 
                 *    auguments to indicate the max sent and received packages number of each time.
                 *    In this example, we send 100 CAN frames by default
                 *    User can change the value of 'nMsgCount' to send different frames each time in this examples.
                 **********************************************************************************************/
            nRet = Device.acCanOpen(CanPortName, false, 500, 500); //Open CAN port
            if (nRet < 0)
            {
                StatusMsg = "Failed to open the CAN port, please check the CAN port name!";
                return false;
            }

            nRet = Device.acEnterResetMode(); //Enter reset mode          
            if (nRet < 0)
            {
                StatusMsg = "Failed to stop opertion!";
                Device.acCanClose();
                return false;
            }
            //Set baud rate
            BaudRateValue = 50; //Get baud rate
            nRet = Device.acSetBaud(BaudRateValue); //Set Baud Rate
            if (nRet < 0)
            {
                StatusMsg = "Failed to set baud!";
                Device.acCanClose();
                return false;
            }


            WriteTimeOutValue = 3000; //Get timeout
            ReadTimeOutValue = WriteTimeOutValue;
            nRet = Device.acSetTimeOut(ReadTimeOutValue, WriteTimeOutValue); //Set timeout
            if (nRet < 0)
            {
                StatusMsg = "Failed to set Timeout!";
                Device.acCanClose();
                return false;
            }

            nRet = Device.acEnterWorkMode(); //Enter work mdoe
            if (nRet < 0)
            {
                StatusMsg = "Failed to restart operation!";
                Device.acCanClose();
                return false;
            }
            ReceiveThreadSt = ReceiveThreadMethod; //Create a new thread
            ReceiveThread = new Thread(ReceiveThreadSt);
            ReceiveThread.Priority = ThreadPriority.Highest;
            ReceiveThread.IsBackground = true;
            ReceiveThread.Start(); //New thread starts

            return true;
        }

        public bool StopExchange()
        {
            m_bRun = false;
            Device.acCanClose();
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
            SendData(dataList);
            SendData(dataList);
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
            SendData(dataList);
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
            SendData(new List<CanDriver.canmsg_t> { msg });
            return true;
        }

        private bool SendData(List<CanDriver.canmsg_t> data)
        {
            string SendStatus;
            int nRet;
            var msgWrite = data; //Package for write   
            uint pulNumberofWritten = 0;
            m_bRun = true;
            SendStatus = "Package ";
            /**********************************************************************************************
                  *  NOTE: acCanWrite usage
                  * 
                  *    DescriptionЈє
                  *       Users can use this interface to send data to CAN port which was opened. 
                  *       One or more frames can be selected each time.
                  * 
                  *    Parameters:
                  *       msgWrite                - managed buffer to write
                  *       nWriteCount             - CAN frame number want to write each time
                  *       pulNumberofWritten      - Real number of frames sent to driver.
                  *    
                  *    In this example, we send 100 CAN frames defined by 'nMsgCount' each time by default.             
                  *    If user want to send one or more frames eache time, user can also change it as follows:
                  *    Firstly, open CAN port and pass the value of 'MsgNumberOfReadBuffer' and 'MsgNumberOfWriteBuffer'arguments.
                  *    About 'MsgNumberOfReadBuffer' and 'MsgNumberOfWriteBuffer', please see 'acCanPort' usage above.
                  *    Secondly, define the msgWrite according to the frame number user want to send each time.
                  *    Thirdly, define the value of 'nWriteCount'according to the frame number user want to send each time.
                  *    In this examples, user can only change the value of 'nMsgCount' to change the count of frame to send each time. 
                 /**********************************************************************************************/
            nRet = Device.acCanWrite(msgWrite.ToArray(), (uint)data.Count, ref pulNumberofWritten); //Send frames
            if (nRet == AdvCANIO.TIME_OUT)
            {
                SendStatus += " sending timeout!";
            }
            else if (nRet == AdvCANIO.OPERATION_ERROR)
            {
                SendStatus += " sending error!";
            }
            else
            {
                SendStatus += " sending ok!";
            }

            //Thread.Sleep(400);
            return true;
        }

        private List<CanDriver.canmsg_t> ReceiveMsgBlock()
        {
            string ReceiveStatus;
            int nRet;
            uint nReadCount = nMsgCount;
            uint pulNumberofRead = 0;

            var msgRead = new CanDriver.canmsg_t[nMsgCount];
            for (int i = 0; i < nMsgCount; i++)
            {
                msgRead[i].data = new byte[8];
            }

            nRet = Device.acCanRead(msgRead, nReadCount, ref pulNumberofRead); //Receiving frames
                if (nRet == AdvCANIO.TIME_OUT)
                {
                    ReceiveStatus = "Package ";
                    ReceiveStatus += "receiving timeout!";
                    return null;
                }
                else if (nRet == AdvCANIO.OPERATION_ERROR)
                {
                    ReceiveStatus = "Package ";
                    ReceiveStatus += " error!";
                    return null;
                }
                else
                    return msgRead.ToList();
                    
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
                            ParameterSubIndex = canmsgT.data[3],
                            Data = new byte[] {canmsgT.data[4], canmsgT.data[5], canmsgT.data[6], canmsgT.data[7]}
                        });
                    else if(canmsgT.data[0] == 0x4B)//sint16
                        canParameters.Add(new CanParameter
                        {
                            ParameterId = (ushort)(canmsgT.data[1] + (canmsgT.data[2] << 8)),
                            ParameterSubIndex = canmsgT.data[3],
                            Data = new byte[] { canmsgT.data[4], canmsgT.data[5]}
                        });
                    else if (canmsgT.data[0] == 0x47)//sint16
                        canParameters.Add(new CanParameter
                        {
                            ParameterId = (ushort)(canmsgT.data[1] + (canmsgT.data[2] << 8)),
                            ParameterSubIndex = canmsgT.data[3],
                            Data = new byte[] { canmsgT.data[4], canmsgT.data[5], canmsgT.data[5] }
                        });
                    //else
                        //GetSegment((ushort) (canmsgT.data[1] + (canmsgT.data[2] << 8)), canmsgT.data[3]);
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
                List<CanDriver.canmsg_t> msgRead = ReceiveMsgBlock();
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
        private uint nMsgCount = 80;
        private Thread ReceiveThread;
        private ThreadStart ReceiveThreadSt;
    }
}
