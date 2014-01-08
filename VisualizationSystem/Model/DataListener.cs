using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComCan;
using ML.AdvCan;
using ML.ConfigSettings.Services;
using ML.DataExchange;
using ML.DataExchange.Interfaces;
using ML.DataExchange.Model;
using VisualizationSystem.View.Forms;

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
            if(IoC.Resolve<MineConfig>().CanName.Contains("CAN"))
                _dataExchange.StartExchange(IoC.Resolve<MineConfig>().CanName, 
                    IoC.Resolve<MineConfig>().CanSpeed, new AdvCANIO());
            else if (IoC.Resolve<MineConfig>().CanName.Contains("COM"))
                _dataExchange.StartExchange(IoC.Resolve<MineConfig>().CanName,
                    IoC.Resolve<MineConfig>().CanSpeed, new ComCANIO()); 
            //_dataExchange.StartExchange("COM7",50, new ComCANIO());
            //_dataExchange.StartExchange("myNonPersisterMemoryMappedFile");
            
        }

        public void SetParameterReceive(Action<List<CanParameter>> receiveFunction)
        {
            _dataExchange.ParameterReceive += receiveFunction;
        }

        public bool GetParameter(ushort parameterId, byte subindex)
        {
            var dialog = new FormCanId {StartPosition = FormStartPosition.CenterScreen};
            dialog.ShowDialog();
            ushort value;
            if(ushort.TryParse(dialog.textBoxAddress.Text, out value))
                return _dataExchange.GetParameter(value, parameterId, subindex);
            return false;
        }

        public bool SetParameter(ushort parameterId, byte subindex, byte[] data)
        {
            var dialog = new FormCanId {StartPosition = FormStartPosition.CenterScreen};
            dialog.ShowDialog();
            ushort value;
            if (ushort.TryParse(dialog.textBoxAddress.Text, out value))
                return _dataExchange.SetParameter(new CanParameter
                {
                    ControllerId = value,
                    ParameterId = parameterId,
                    ParameterSubIndex = subindex,
                    Data = data
                });
            return false;
        }
    }
}
