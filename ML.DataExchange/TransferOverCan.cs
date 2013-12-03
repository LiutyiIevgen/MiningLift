using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ML.DataExchange.CanDriver;
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
            ReceiveThread.Priority = ThreadPriority.Normal;
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

        private void ReceiveThreadMethod()
        {
            string ReceiveStatus;
            int nRet;
            uint nReadCount = nMsgCount;
            uint pulNumberofRead = 0;
            uint ReceiveIndex = 0;

            var msgRead = new AdvCan.canmsg_t[nMsgCount];
            for (int i = 0; i < nMsgCount; i++)
            {
                msgRead[i].data = new byte[8];
            }


            ReceiveIndex = 0;
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
                nRet = Device.acCanRead(msgRead, nReadCount, ref pulNumberofRead); //Receiving frames
                if (nRet == AdvCANIO.TIME_OUT)
                {
                    ReceiveStatus = "Package ";
                    ReceiveStatus += "receiving timeout!";
                }
                else if (nRet == AdvCANIO.OPERATION_ERROR)
                {
                    ReceiveStatus = "Package ";
                    ReceiveStatus += " error!";
                }
                else
                {
                    Parameters parameters;
                    if (pulNumberofRead > 4)
                    {
                        parameters = ParametersParser(msgRead.ToList());
                        ReceiveEvent(parameters);
                    }
                    /*for (int j = 0; j < pulNumberofRead; j++)
                    {
                        ReceiveStatus = "Package ";
                        ReceiveStatus += Convert.ToString(ReceiveIndex + j + 1) + " is ";
                        if (msgRead[j].id == AdvCan.ERRORID)
                        {
                            ReceiveStatus += "a incorrect package";
                        }
                        else
                        {
                            if ((msgRead[j].flags & AdvCan.MSG_RTR) > 0)
                            {
                                ReceiveStatus += "a RTR package";
                            }
                            else
                            {
                               
                                    //ReceiveStatus += msgRead[j].data[i].ToString();
                                Parameters parameters = ParametersParser(msgRead.ToList());
                                    //ReceiveStatus += " ";
                            }
                        }
                    }*/
                }
                ReceiveIndex += pulNumberofRead;
                Thread.Sleep(100);
            }
        }

        Parameters ParametersParser(List<AdvCan.canmsg_t> msgData)
        {
            var param = new double[30];
            for (int i = 0; i < param.Length; i++)
            {
                param[i] = 0;
            }
            try
            {
                param[0] = CanParser.GetS(msgData);
                double v = CanParser.GetV(msgData);
                param[1] = Math.Abs(v);
                param[2] = CanParser.GetA(msgData);
                param[5] = CanParser.GetStart(v);
                param[8] = CanParser.GetBack(v);
                param[9] = CanParser.GetOstanov(v);
            }
            catch (Exception)
            {
                
            }
            return new Parameters(param);
        }
        public event ReceiveHandler ReceiveEvent;

        private readonly AdvCANIO Device;
        private bool m_bRun;
        private bool syncflag;
        private uint nMsgCount = 50;
        private Thread ReceiveThread;
        private ThreadStart ReceiveThreadSt;
    }
}
