using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ML.DataExchange;
using ML.DataExchange.Interfaces;

namespace VisualizationSystem.Model
{
    class DataListener
    {
        private IDataExchange _dataExchange;
        public DataListener(IDataExchange dataExchange)
        {
            _dataExchange = dataExchange;
        }

        public void Init(ReceiveHandler Function)
        {
            _dataExchange.StartExchange("CAN1");
            //_dataExchange.StartExchange("COM7");
            //_dataExchange.StartExchange("myNonPersisterMemoryMappedFile");
            _dataExchange.ReceiveEvent += Function;
        }

        public void SetParameterReceive(Action<List<CanParameter>> receiveFunction)
        {
            _dataExchange.ParameterReceive += receiveFunction;
        }

        public bool GetParameter(ushort parameterId, byte subindex)
        {
            return _dataExchange.GetParameter(parameterId, subindex);
        }

        public bool SetParameter(ushort parameterId, byte subindex, byte[] data)
        {
            return _dataExchange.SetParameter(new CanParameter
            {
                ParameterId = parameterId, ParameterSubIndex = subindex, Data = data
            });
        }
    }
}
