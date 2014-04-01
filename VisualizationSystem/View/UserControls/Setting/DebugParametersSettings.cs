using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ML.ConfigSettings.Services;
using VisualizationSystem.Model;

namespace VisualizationSystem.View.UserControls.Setting
{
    public partial class DebugParametersSettings : UserControl
    {
        public DebugParametersSettings()
        {
            InitializeComponent();
            textBoxLeadController.Text = IoC.Resolve<MineConfig>().LeadingController.ToString();
            textBoxMaxDopMismatch.Text = IoC.Resolve<MineConfig>().MaxDopMismatch.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IoC.Resolve<MineConfig>().LeadingController = Convert.ToInt32(textBoxLeadController.Text);
            IoC.Resolve<MineConfig>().MaxDopMismatch = Convert.ToInt32(textBoxMaxDopMismatch.Text);
        }
    }
}
