using System;
using System.Data.Entity;
using System.Windows.Forms;
using ML.DataRepository.DataAccess;
using ML.DataRepository.Models.GenericRepository;
using VisualizationSystem.Model;
using VisualizationSystem.Services;
using VisualizationSystem.View;
using ML.ConfigSettings.Services;

namespace VisualizationSystem
{
    public partial class Form1 : Form
    {
        MainView _mainView = new MainView();
        public Form1()
        {
            InitializeComponent();
            //
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //IoC.Resolve<MineConfig>().MainViewConfig.MaxSpeed.Value = 5;

            ConfigParameters.ReadConfigParameters();
            SetMainView();
            FormSettings f2 = IoC.Resolve<FormSettings>();
            FormSettingsParol f3 = IoC.Resolve<FormSettingsParol>();
            FormCodtDomainParamType f4 = IoC.Resolve<FormCodtDomainParamType>();
            /*using (var repoUnit = new RepoUnit())
            {
                double value = repoUnit.SettingsLog.FindFirstBy(f => f.Name == "MaxCurrentValue").DValue;
            } */
        }

        private void SetMainView()
        {
            _mainView.Dock = System.Windows.Forms.DockStyle.Fill;
           // this.Controls.Remove(_mainView);
            panel1.Controls.Add(_mainView);
        }

    }
}
