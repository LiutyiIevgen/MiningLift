using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ML.ConfigSettings.Services;
using VisualizationSystem.Model;

namespace VisualizationSystem.View.Forms
{
    public partial class FormAddParameterSettings : Form
    {
        public FormAddParameterSettings()
        {
            InitializeComponent();
        }

        private void FormAddParameterSettings_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            List<string> strList = IoC.Resolve<MineConfig>().ParametersConfig.VariableParametersName.ToList();
            strList.Add(textBox1.Text);
            IoC.Resolve<MineConfig>().ParametersConfig.VariableParametersName = strList.ToArray();
            strList = IoC.Resolve<MineConfig>().ParametersConfig.VariableParametersType.ToList();
            strList.Add(comboBox1.Text);
            IoC.Resolve<MineConfig>().ParametersConfig.VariableParametersType = strList.ToArray();
            strList = IoC.Resolve<MineConfig>().ParametersConfig.VariableParametersValue.ToList();
            strList.Add(textBox2.Text);
            IoC.Resolve<MineConfig>().ParametersConfig.VariableParametersValue = strList.ToArray();
            MessageBox.Show("Новый параметр добавлен успешно!", "Добавление параметра", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "codtDomain")
            {
                textBox2.Text = "Двоичные данные";
                textBox2.ReadOnly = true;
            }
            else
            {
                textBox2.ReadOnly = false;
            }
        }

    }
}
