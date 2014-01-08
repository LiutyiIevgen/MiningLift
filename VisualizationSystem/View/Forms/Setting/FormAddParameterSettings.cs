using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ML.ConfigSettings.Services;
using VisualizationSystem.Model;

namespace VisualizationSystem.View.Forms.Setting
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
