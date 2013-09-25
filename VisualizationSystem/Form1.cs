using System;
using System.Windows.Forms;
using VisualizationSystem.Model;
using VisualizationSystem.Services;
using VisualizationSystem.View;

namespace VisualizationSystem
{
    public partial class Form1 : Form
    {
        MainView _mainView = new MainView();
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MineConfig mineConfig = IoC.Resolve<MineConfig>();
            //mineConfig.MainViewConfig.MaxSpeed.Value = 5;

            ConfigParameters.ReadConfigParameters();
            SetMainView();
        }

        private void SetMainView()
        {
            _mainView.Dock = System.Windows.Forms.DockStyle.Fill;
           // this.Controls.Remove(_mainView);
            panel1.Controls.Add(_mainView);
        }

    }
}
