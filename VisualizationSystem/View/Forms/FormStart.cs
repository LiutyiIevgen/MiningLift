using System;
using System.Windows.Forms;
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
            /*using (var repoUnit = new RepoUnit())
            {
                double value = repoUnit.SettingsLog.FindFirstBy(f => f.Name == "MaxCurrentValue").DValue;
            } */
        }

        private void SetMainView()
        {          
            _mainView = new MainView{Dock = System.Windows.Forms.DockStyle.Fill};
            panel1.Controls.Add(_mainView);
            _mainView.MainView_Load();
           // this.Controls.Remove(_mainView);
            
        }
        private MainView _mainView;
    }
}
