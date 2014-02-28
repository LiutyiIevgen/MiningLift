using System;
using System.Windows.Forms;
using ML.DataRepository.Models.GenericRepository;
using VisualizationSystem.View.UserControls;
using VisualizationSystem.View.UserControls.GeneralView;

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
