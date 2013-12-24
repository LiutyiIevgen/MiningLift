

using System;
using System.Collections.Generic;
using ML.AdvCan;

namespace ML.DataExchange.Interfaces
{
    public delegate void ReceiveHandler(Parameters parameters);
    public interface IDataExchange
    {
        //server initialization
        bool StartExchange(string strPort);

        bool GetParameter(ushort parameterId, byte subindex);
        bool SetParameter(CanParameter canParameter);
        //close all connection
        bool StopExchange();

        event ReceiveHandler ReceiveEvent; //visualisation info

        event Action<List<CanParameter>> ParameterReceive; //inner parameters info
    }
}
