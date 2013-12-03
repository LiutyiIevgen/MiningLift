using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            _dataExchange.ReceiveEvent += Function;
        }
    }
}
