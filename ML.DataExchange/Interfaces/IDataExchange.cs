

using System;

namespace ML.DataExchange.Interfaces
{
    public delegate void ReceiveHandler(Parameters parameters);
    public interface IDataExchange
    {
        //server initialization
        bool StartExchange(string strPort);
        //close all connection
        bool StopExchange();

        event ReceiveHandler ReceiveEvent;
    }
}
