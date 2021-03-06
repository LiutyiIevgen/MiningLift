﻿using System;
using System.Windows.Forms;
using ML.DataRepository.Models.GenericRepository;
using VisualizationSystem.View.UserControls;

namespace VisualizationSystem.View.Forms
{
    public partial class FormStart : Form
    {
        public FormStart()
        { 
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();    
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ConfigParameters.ReadConfigParameters();
            
            //FormSettings f2 = IoC.Resolve<FormSettings>();
            //FormSettingsParol f3 = IoC.Resolve<FormSettingsParol>();
            SetMainView();
        }

        private void SetMainView()
        {          
            _mainView = new MainView {Dock = System.Windows.Forms.DockStyle.Fill};
            _mainView.Width = this.Width;
            _mainView.Height = this.Height;
            panel1.Controls.Add(_mainView);
            _mainView.MainView_Load();
        }
        private MainView _mainView;
    }
}
