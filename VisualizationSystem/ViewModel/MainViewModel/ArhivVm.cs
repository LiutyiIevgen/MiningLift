using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ML.ConfigSettings.Services;
using VisualizationSystem.Model;
using VisualizationSystem.Services;

namespace VisualizationSystem.ViewModel.MainViewModel
{
    class ArhivVm
    {
        public TreeNode[] GetNodesList(DateTime from, DateTime till)
        {
            _blocksIds = _dataBaseService.GetBlocksIds(from, till);
            if (_blocksIds.Count == 0)
                return new TreeNode[0];
            _currentId = 0;
            return GenereteNodesList();
        }

        public TreeNode[] GetNextNodesList()
        {
            if (_currentId == _blocksIds.Count - 1)
                _currentId = 0;
            else
                _currentId++;
            return GenereteNodesList();
        }

        public TreeNode[] GetPrevNodesList()
        {
            if (_currentId == 0)
                _currentId = _blocksIds.Count - 1;
            else
                _currentId--;
            return GenereteNodesList();
        }

        public int CurrentId
        {
            get { return _currentId + 1; }
        }

        public int RecordsNum
        {
            get { return _blocksIds.Count(); }
        }

        private TreeNode[] GenereteNodesList()
        {
            if(_blocksIds.Count == 0)
                return new TreeNode[0];
            //get analog signals list
            var signalsList = _dataBaseService.GetAnalogSignalsById(_blocksIds[_currentId]);
            var analogNodes = new List<TreeNode>();
            signalsList.ForEach(s => analogNodes.Add(new TreeNode(s.Name + " = " + s.Value.ToString())));

            //get input signals list
            var inputNodes = new List<TreeNode>();
            signalsList = _dataBaseService.GetInputSignalsById(_blocksIds[_currentId]);
            var signalsNames = IoC.Resolve<MineConfig>().AuziDSignalsConfig.SignalsNames;
            for (int i = 0; i < signalsList.Count; i++)
            {
                signalsList[i].Name = signalsNames[i];
            }
            signalsList.ForEach(s => inputNodes.Add(new TreeNode(s.Name + " = " + s.Value.ToString())));

            //get output signals list
            var outputNodes = new List<TreeNode>();
            signalsList = _dataBaseService.GetInputSignalsById(_blocksIds[_currentId]);
            for (int i = 0; i < signalsList.Count; i++)
            {
                signalsList[i].Name = signalsNames[i+72];
            }
            signalsList.ForEach(s => outputNodes.Add(new TreeNode(s.Name + " = " + s.Value.ToString())));

            var block = _dataBaseService.GetBlockLogById(_blocksIds[_currentId]);
            var mainNodes = new TreeNode[4]
            {
                new TreeNode(block.Date.ToString()), 
                new TreeNode("Аналоговые сигналы", analogNodes.ToArray()),
                new TreeNode("Входные сигналы", inputNodes.ToArray()), new TreeNode("Выходные сигналы", outputNodes.ToArray()) 
            };
            return mainNodes;
        }


        readonly DataBaseService _dataBaseService = new DataBaseService();
        private List<int> _blocksIds;
        private int _currentId = 0;
    }
}
