using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComCan;
using ML.AdvCan;
using ML.DataExchange;
using ML.DataExchange.Interfaces;
using ML.DataExchange.Model;

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
            _dataExchange.ReceiveEvent += Function;
            _dataExchange.StartExchange("CAN1",50, new AdvCANIO());
            //_dataExchange.StartExchange("COM7",50, new ComCANIO());
            //_dataExchange.StartExchange("myNonPersisterMemoryMappedFile");
            
        }

        public void SetParameterReceive(Action<List<CanParameter>> receiveFunction)
        {
            _dataExchange.ParameterReceive += receiveFunction;
        }

        public bool GetParameter(ushort parameterId, byte subindex)
        {
            return _dataExchange.GetParameter(1,parameterId, subindex);
        }

        public bool SetParameter(ushort parameterId, byte subindex, byte[] data)
        {
            return _dataExchange.SetParameter(1,new CanParameter
            {
                ParameterId = parameterId, ParameterSubIndex = subindex, Data = data
            });
        }
    }
}
