﻿using System;
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
        ParametersSettings _parametersSettings = new ParametersSettings();
        DefenceDiagramSettings _defenceDiagramSettings;
        public FormSettings()
        {
            InitializeComponent();
            //start
            AuziDButton.BackColor = Color.Gainsboro;
            ParametersButton.BackColor = Color.Gainsboro;
            DefenceDiagramButton.BackColor = Color.Gainsboro;
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
            ParametersButton.BackColor = Color.Gainsboro;
            DefenceDiagramButton.BackColor = Color.Gainsboro;
            MainViewSettingsButton.BackColor = SystemColors.ActiveCaption;
            _mainViewSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(_mainViewSettings);
        }

        private void AuziDButton_Click(object sender, EventArgs e)
        {
            MainViewSettingsButton.BackColor = Color.Gainsboro;
            ParametersButton.BackColor = Color.Gainsboro;
            DefenceDiagramButton.BackColor = Color.Gainsboro;
            AuziDButton.BackColor = SystemColors.ActiveCaption;
            _auziDSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(_auziDSettings);
        }

        private void ParametersButton_Click(object sender, EventArgs e)
        {
            MainViewSettingsButton.BackColor = Color.Gainsboro;
            AuziDButton.BackColor = Color.Gainsboro;
            DefenceDiagramButton.BackColor = Color.Gainsboro;
            ParametersButton.BackColor = SystemColors.ActiveCaption;
            _parametersSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(_parametersSettings);
        }

        private void DefenceDiagramButton_Click(object sender, EventArgs e)
        {
            MainViewSettingsButton.BackColor = Color.Gainsboro;
            AuziDButton.BackColor = Color.Gainsboro;
            ParametersButton.BackColor = Color.Gainsboro;
            DefenceDiagramButton.BackColor = SystemColors.ActiveCaption;
            _defenceDiagramSettings = new DefenceDiagramSettings();
            _defenceDiagramSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(_defenceDiagramSettings);
        }


    }
}