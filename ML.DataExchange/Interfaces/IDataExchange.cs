

using System;
using System.Collections.Generic;

namespace ML.DataExchange.Interfaces
{
    public delegate void ReceiveHandler(Parameters parameters);
    public interface IDataExchange
    {
        //server initialization
        bool StartExchange(string strPort);

        bool GetParameter(ushort parameterId);
        //close all connection
        bool StopExchange();

        event ReceiveHandler ReceiveEvent; //visualisation info

        event Action<List<CanParameter>> ParameterReceive; //inner parameters info
    }
}
