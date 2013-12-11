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

        public bool GetParameter(ushort parameterId)
        {
            var dataList = new List<AdvCan.canmsg_t>();
            var msg = new AdvCan.canmsg_t();
            msg.flags = AdvCan.MSG_BOVR;
            msg.cob = 0;
            msg.id = 0x601; //rSdo + id=1
            msg.length = (short)AdvCan.DATALENGTH;
            msg.data = new byte[AdvCan.DATALENGTH];
            msg.data[0] = 0x40;
            msg.data[1] = (byte)(parameterId);//id low
            msg.data[2] = (byte)(parameterId>>8);//id high
            msg.data[3] = 0x02;//subindex
            dataList.Add(msg);
            SendData(dataList);
            return true;
        }

        private bool SendData(List<AdvCan.canmsg_t> data)
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
                }
                ReceiveIndex += pulNumberofRead;
                Thread.Sleep(20);
            }
        }

        private Parameters ParametersParser(List<AdvCan.canmsg_t> msgData)
        {
            Parameters parameters;
            var param = new double[30];
            var outputSignals = new List<AuziDState>();
            var inputSignals = new List<AuziDState>();
            for (int i = 0; i < param.Length; i++)
            {
                param[i] = 0;
            }
            try
            {
                param[0] = CanParser.GetS1(msgData);
                double v = CanParser.GetV(msgData);
                param[1] = Math.Abs(v);
                param[2] = CanParser.GetA(msgData);
                param[5] = CanParser.GetStart(v);
                param[8] = CanParser.GetBack(v);
                param[9] = CanParser.GetOstanov(msgData);
                param[12] = CanParser.GetS2(msgData);
                inputSignals = CanParser.GetAllInputSignals(msgData);
                outputSignals = CanParser.GetAllOutputSignals(msgData);
                var canParameters = CanParser.TryGetParameterValue(msgData);
                if (canParameters.Count != 0)
                    ParameterReceive(canParameters);
            }
            catch (Exception)
            {
            }
            parameters = new Parameters(param);
            parameters.SetAuziDOSignalsState(outputSignals);
            parameters.SetAuziDISignalsState(inputSignals);
            return parameters;
        }


        public event ReceiveHandler ReceiveEvent;

        public event Action<List<CanParameter>> ParameterReceive;

        private readonly AdvCANIO Device;
        private bool m_bRun;
        private bool syncflag;
        private uint nMsgCount = 10;
        private Thread ReceiveThread;
        private ThreadStart ReceiveThreadSt;
    }
}
