using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VisualizationSystem.View
{
    public partial class FormSettings : Form
    {
        MainViewSettings _mainViewSettings = new MainViewSettings();
        public FormSettings()
        {
            InitializeComponent();
            //start
            button1.BackColor = Color.Gainsboro;
            MainViewSettingsButton.BackColor = SystemColors.ActiveCaption;
            _mainViewSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(_mainViewSettings);
        }

        private void MainViewSettingsButton_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Gainsboro;
            MainViewSettingsButton.BackColor = SystemColors.ActiveCaption;
            _mainViewSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(_mainViewSettings);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainViewSettingsButton.BackColor = Color.Gainsboro;
            button1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Clear();
        }

    }
}
