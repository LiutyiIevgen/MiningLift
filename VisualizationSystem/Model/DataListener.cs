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

        public void Init(ReceiveHandler Function, Action DrawLoad)
        {
            _dataExchange.StartExchange("myNonPersisterMemoryMappedFile");
            _dataExchange.ReceiveEvent += Function;
            _dataExchange.DrawLoad += DrawLoad;
        }
    }
}
