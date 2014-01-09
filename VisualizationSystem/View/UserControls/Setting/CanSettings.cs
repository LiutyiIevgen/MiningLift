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
    public partial class CanSettings : UserControl
    {
        public CanSettings()
        {
            InitializeComponent();
        }

        private void CanSettings_Load(object sender, EventArgs e)
        {
            textBox1.Text = IoC.Resolve<MineConfig>().CanName;
            comboBoxCanSpeed.Text = IoC.Resolve<MineConfig>().CanSpeed.ToString();
            textBox2.Text = IoC.Resolve<MineConfig>().LeadingController.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IoC.Resolve<MineConfig>().CanName = textBox1.Text;
            IoC.Resolve<MineConfig>().CanSpeed = Convert.ToInt32(comboBoxCanSpeed.Text);
            IoC.Resolve<MineConfig>().LeadingController = Convert.ToInt32(textBox2.Text);
            IoC.Resolve<DataListener>().Init(null);
        }
    }
}
