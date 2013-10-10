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
        AuziDSettings _auziDSettings = new AuziDSettings();
        public FormSettings()
        {
            InitializeComponent();
            //start
            AuziDButton.BackColor = Color.Gainsboro;
            MainViewSettingsButton.BackColor = SystemColors.ActiveCaption;
            _mainViewSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(_mainViewSettings);
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
        }

        private void MainViewSettingsButton_Click(object sender, EventArgs e)
        {
            AuziDButton.BackColor = Color.Gainsboro;
            MainViewSettingsButton.BackColor = SystemColors.ActiveCaption;
            _mainViewSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(_mainViewSettings);
        }

        private void AuziDButton_Click(object sender, EventArgs e)
        {
            MainViewSettingsButton.BackColor = Color.Gainsboro;
            AuziDButton.BackColor = SystemColors.ActiveCaption;
            _auziDSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(_auziDSettings);
        }



    }
}
