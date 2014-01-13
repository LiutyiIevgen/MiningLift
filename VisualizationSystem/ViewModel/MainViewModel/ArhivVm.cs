using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualizationSystem.ViewModel.MainViewModel
{
    class ArhivVm
    {
        public TreeNode[] GetNodesList()
        {
            var analogNodes = new TreeNode[2]
            {
                new TreeNode("S1 = 2"),
                new TreeNode("S2 = 3")
            };
            var mainNodes = new TreeNode[3]
            {
                new TreeNode("Аналоговые сигналы", analogNodes),
                new TreeNode(), new TreeNode() 
            };
            return mainNodes;
        }
    }
}
