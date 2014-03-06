using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ML.ConfigSettings.Model;
using ML.ConfigSettings.Services;
using ML.DataExchange.Model;
using VisualizationSystem.Model;
using VisualizationSystem.Services;
using VisualizationSystem.View.Forms.Setting;
using VisualizationSystem.ViewModel;
using VisualizationSystem.ViewModel.MainViewModel;

namespace VisualizationSystem.View.UserControls.GeneralView
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
            _cycleUc = new CycleUC(){Dock = DockStyle.Fill};
            _cepTpUc = new CepTpUC() {Dock = DockStyle.Fill};
            _auziDUc = new AuziDUC() {Dock = DockStyle.Fill};

            tabPage1.Controls.Add(_cycleUc);
            tabPage2.Controls.Add(_cepTpUc);
            tabPage3.Controls.Add(_auziDUc);

            _dataListener = IoC.Resolve<DataListener>();
            IoC.Resolve<CanStateService>().StartListener();
            _mineConfig = IoC.Resolve<MineConfig>();
        }
        public void MainView_Load()
        {

            //view models creation
            _leftPanelVm = new LeftPanelVm(panel1.Width, panel1.Height);
            _rightPanelVm = new RightPanelVm(panel2.Width, panel2.Height);
            _leftDopPanelVm = new LeftDopPanelVm(panel6.Width, panel6.Height);
            _rightDopPanelVm = new RightDopPanelVm(panel7.Width, panel7.Height);
            _speedPanelVm = new SpeedPanelVm(panel3.Width, panel3.Height);
            _tokAnchorPanelVm = new TokAnchorPanelVm(panel4.Width, panel4.Height);
            _tokExcitationPanelVm = new TokExcitationPanelVm(panel5.Width, panel5.Height);
            
            _loadDataVm = new LoadDataVm();
            _dataBoxVm = new DataBoxVm();
            
            _dataBaseService = IoC.Resolve<DataBaseService>();

            var param = new double[30];
            ViewData(new Parameters(param));

            _dataListener.Init(ViewData);
            _dataListener.SetAllCanDataReceive(_auziDUc.UpdateAuziDControllerParameters);
            _dataListener.SetAllCanDataReceive(_dataBaseService.FillDataBase);
            var arhivWriterThread = new Thread(ArhivWriterThread){ IsBackground = true, Priority = ThreadPriority.Lowest};
            arhivWriterThread.Start();
            var timeThread = new Thread(TimeThread) {IsBackground = true, Priority = ThreadPriority.Lowest};
            timeThread.Start();
        }

        public void ViewData(Parameters parameters)
        {
            _parameters = parameters;
            
            //
            Settings.UpZeroZone = _mineConfig.MainViewConfig.UpZeroZone.Value;
            //
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            UpdateLeftPanel(parameters);
            UpdateRightPanel(parameters);
            UpdateSpeedPanel(parameters);
            UpdateTokAnchorPanel(parameters);
            UpdateTokExitationPanel(parameters);
            UpdateLeftDopPanel(parameters);
            UpdateRightDopPanel(parameters);
            

            UpdateDataBoxes(parameters);
            UpdateLoadData(parameters);

            if (update_parameters_flag%3==0)
                _cycleUc.Refresh(parameters);
            if (update_parameters_flag%20 == 0)
            {
                _cepTpUc.Refresh(parameters); 
                _auziDUc.Refresh(parameters);
                update_parameters_flag = 0;
            }
            update_parameters_flag++;
            //stopwatch.Stop();
            //stopwatch = null;
        }

        #region Threads
        private void ArhivWriterThread()
        {
            while (true)
            {
                if (_mineConfig.MainViewConfig.ArchiveState == ArchiveState.Active)
                    _dataBaseService.LetFillDataBase();
                Thread.Sleep(1000);
            } 
        }

        private void TimeThread()
        {
            while (true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    labelTime.Text = DateTime.Now.ToLongTimeString();
                    labelDate.Text = DateTime.Now.ToShortDateString();
                    labelCanState.Text = _mineConfig.CanName;
                    labelCanState.ForeColor = _dataBoxVm.CanStateColor;
                });
                Thread.Sleep(1000);
            }    
        }
        #endregion

        #region ViewModel binding


        

        

        private void UpdateLeftPanel(Parameters parameters)
        {
            btBac = new Bitmap(panel1.Width, panel1.Height); // панель клети
            Graphics g = Graphics.FromImage(btBac);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            _leftPanelVm.InitVm(parameters);
            _leftPanelVm.GetMainRuleDatas().ForEach(l => g.DrawLine(l.Pen, l.FirstPoint, l.SecondPoint));
            _leftPanelVm.GetMainRuleInscription().ForEach(s => g.DrawString(s.Text, s.Font, s.Brush, s.Position));
            _leftPanelVm.GetMainRuleZones().ForEach(z => g.FillRectangle(z.Brush, z.LeftTopX, z.LeftTopY, z.Width, z.Height));
            if (_mineConfig.MainViewConfig.LeftSosud == SosudType.Skip)
                _leftPanelVm.GetMainRulePointerLineSkip().ForEach(pl => g.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
            else
                _leftPanelVm.GetMainRulePointerLineBackBalance().ForEach(pl => g.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
            _leftPanelVm.GetMainRulePointer().ForEach(p => g.DrawPolygon(p.Pen, p.Triangle));
            _leftPanelVm.GetMainRuleFillPointer().ForEach(fp => g.FillPolygon(fp.Brush, fp.Triangle));
            _leftPanelVm.GetMainRuleCage().ForEach(c => g.FillRectangle(c.Brush, c.LeftTopX, c.LeftTopY, c.Width, c.Height));
            if (_mineConfig.MainViewConfig.LeftSosud == SosudType.Skip)
                _leftPanelVm.GetMainRuleDirectionPointerSkip().ForEach(dp => g.DrawPolygon(dp.Pen, dp.Triangle));
            else
                _leftPanelVm.GetMainRuleDirectionPointerBackBalance().ForEach(dp => g.DrawPolygon(dp.Pen, dp.Triangle));
            _leftPanelVm.GetMainRuleDirectionFillPointer().ForEach(dfp => g.FillPolygon(dfp.Brush, dfp.Triangle));
            g.Dispose();
            panel1.Invalidate();
        }

        private void UpdateRightPanel(Parameters parameters)
        {
            btBac_two = new Bitmap(panel2.Width, panel2.Height); // панель противовеса
            Graphics gr = Graphics.FromImage(btBac_two);
            gr.SmoothingMode = SmoothingMode.AntiAlias;

            _rightPanelVm.InitVm(parameters);
            _rightPanelVm.GetMainRuleDatas().ForEach(l => gr.DrawLine(l.Pen, l.FirstPoint, l.SecondPoint));
            _rightPanelVm.GetMainRuleInscription().ForEach(s => gr.DrawString(s.Text, s.Font, s.Brush, s.Position));
            _rightPanelVm.GetMainRuleZones().ForEach(z => gr.FillRectangle(z.Brush, z.LeftTopX, z.LeftTopY, z.Width, z.Height));
            if (_mineConfig.MainViewConfig.RightSosud == SosudType.Skip)
                _rightPanelVm.GetMainRulePointerLineSkip().ForEach(pl => gr.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
            else
                _rightPanelVm.GetMainRulePointerLineBackBalance().ForEach(pl => gr.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
            _rightPanelVm.GetMainRulePointer().ForEach(p => gr.DrawPolygon(p.Pen, p.Triangle));
            _rightPanelVm.GetMainRuleFillPointer().ForEach(fp => gr.FillPolygon(fp.Brush, fp.Triangle));
            _rightPanelVm.GetMainRuleCage().ForEach(c => gr.FillRectangle(c.Brush, c.LeftTopX, c.LeftTopY, c.Width, c.Height));
            if (_mineConfig.MainViewConfig.RightSosud == SosudType.Skip)
                _rightPanelVm.GetMainRuleDirectionPointerSkip().ForEach(dp => gr.DrawPolygon(dp.Pen, dp.Triangle));
            else
                _rightPanelVm.GetMainRuleDirectionPointerBackBalance().ForEach(dp => gr.DrawPolygon(dp.Pen, dp.Triangle));
            _rightPanelVm.GetMainRuleDirectionFillPointer().ForEach(dfp => gr.FillPolygon(dfp.Brush, dfp.Triangle));
            gr.Dispose();
            panel2.Invalidate();
        }

        private void UpdateLeftDopPanel(Parameters parameters)
        {
            btBac_dop = new Bitmap(panel6.Width, panel6.Height); // панель дополнительной шккалы клети
            Graphics gd = Graphics.FromImage(btBac_dop);
            gd.SmoothingMode = SmoothingMode.AntiAlias;

            _leftDopPanelVm.InitVm(parameters);
            _leftDopPanelVm.GetDopRuleDatas().ForEach(l => gd.DrawLine(l.Pen, l.FirstPoint, l.SecondPoint));
            _leftDopPanelVm.GetDopRuleInscription().ForEach(s => gd.DrawString(s.Text, s.Font, s.Brush, s.Position));
            _leftDopPanelVm.GetDopRulePointerLine().ForEach(pl => gd.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
            _leftDopPanelVm.GetDopRulePointer().ForEach(p => gd.DrawPolygon(p.Pen, p.Triangle));
            _leftDopPanelVm.GetDopRuleFillPointer().ForEach(fp => gd.FillPolygon(fp.Brush, fp.Triangle));
            _leftDopPanelVm.GetDopRulePanelBorderLine().ForEach(c => gd.DrawRectangle(c.Pen, c.LeftTopX, c.LeftTopY, c.Width, c.Height));
            gd.Dispose();
            panel6.Invalidate();
        }

        private void UpdateRightDopPanel(Parameters parameters)
        {
            btBac_two_dop = new Bitmap(panel7.Width, panel7.Height); // панель дополнительной шкалы пртивовеса
            Graphics grd = Graphics.FromImage(btBac_two_dop);
            grd.SmoothingMode = SmoothingMode.AntiAlias;

            _rightDopPanelVm.InitVm(parameters);
            _rightDopPanelVm.GetDopRuleDatas().ForEach(l => grd.DrawLine(l.Pen, l.FirstPoint, l.SecondPoint));
            _rightDopPanelVm.GetDopRuleInscription().ForEach(s => grd.DrawString(s.Text, s.Font, s.Brush, s.Position));
            _rightDopPanelVm.GetDopRulePointerLine().ForEach(pl => grd.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
            _rightDopPanelVm.GetDopRulePointer().ForEach(p => grd.DrawPolygon(p.Pen, p.Triangle));
            _rightDopPanelVm.GetDopRuleFillPointer().ForEach(fp => grd.FillPolygon(fp.Brush, fp.Triangle));
            _rightDopPanelVm.GetDopRulePanelBorderLine().ForEach(c => grd.DrawRectangle(c.Pen, c.LeftTopX, c.LeftTopY, c.Width, c.Height));
            grd.Dispose();
            panel7.Invalidate();
        }

        private void UpdateSpeedPanel(Parameters parameters)
        {
            btBac_speed = new Bitmap(panel3.Width, panel3.Height); // панель скорости
            Graphics gs = Graphics.FromImage(btBac_speed);
            gs.SmoothingMode = SmoothingMode.AntiAlias;

            _speedPanelVm.InitVm(parameters);
            _speedPanelVm.GetSpeedRuleDatas().ForEach(l => gs.DrawLine(l.Pen, l.FirstPoint, l.SecondPoint));
            _speedPanelVm.GetSpeedRuleInscription().ForEach(s => gs.DrawString(s.Text, s.Font, s.Brush, s.Position));
            _speedPanelVm.GetSpeedRulePointerLine().ForEach(pl => gs.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
            _speedPanelVm.GetSpeedRulePointer().ForEach(p => gs.DrawPolygon(p.Pen, p.Triangle));
            _speedPanelVm.GetSpeedRuleFillPointer().ForEach(fp => gs.FillPolygon(fp.Brush, fp.Triangle));
            _speedPanelVm.GetSpeedRuleSpeedMeaningZone().ForEach(sp => gs.FillRectangle(sp.Brush, sp.LeftTopX, sp.LeftTopY, sp.Width, sp.Height));
            gs.Dispose();
            panel3.Invalidate();
        }

        private void UpdateTokAnchorPanel(Parameters parameters)
        {
            btBac_tok_anchor = new Bitmap(panel4.Width, panel4.Height); // панель тока якоря
            Graphics gta = Graphics.FromImage(btBac_tok_anchor);
            gta.SmoothingMode = SmoothingMode.AntiAlias;

            _tokAnchorPanelVm.InitVm(parameters);
            _tokAnchorPanelVm.GetTokAnchorRuleDatas().ForEach(l => gta.DrawLine(l.Pen, l.FirstPoint, l.SecondPoint));
            _tokAnchorPanelVm.GetTokAnchorRuleInscription().ForEach(s => gta.DrawString(s.Text, s.Font, s.Brush, s.Position));
            _tokAnchorPanelVm.GetTokAnchorRulePointerLine().ForEach(pl => gta.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
            _tokAnchorPanelVm.GetTokAnchorRulePointer().ForEach(p => gta.DrawPolygon(p.Pen, p.Triangle));
            _tokAnchorPanelVm.GetTokAnchorRuleFillPointer().ForEach(fp => gta.FillPolygon(fp.Brush, fp.Triangle));
            _tokAnchorPanelVm.GetTokAnchorRuleTokAnchorMeaningZone().ForEach(sp => gta.FillRectangle(sp.Brush, sp.LeftTopX, sp.LeftTopY, sp.Width, sp.Height));
            gta.Dispose();
            panel4.Invalidate();
        }

        private void UpdateTokExitationPanel(Parameters parameters)
        {
            btBac_tok_excitation = new Bitmap(panel5.Width, panel5.Height); // панель тока возбуждения
            Graphics gte = Graphics.FromImage(btBac_tok_excitation);
            gte.SmoothingMode = SmoothingMode.AntiAlias;

            _tokExcitationPanelVm.InitVm(parameters);
            _tokExcitationPanelVm.GetTokExcitationRuleDatas().ForEach(l => gte.DrawLine(l.Pen, l.FirstPoint, l.SecondPoint));
            _tokExcitationPanelVm.GetTokExcitationRuleInscription().ForEach(s => gte.DrawString(s.Text, s.Font, s.Brush, s.Position));
            _tokExcitationPanelVm.GetTokExcitationRulePointerLine().ForEach(pl => gte.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
            _tokExcitationPanelVm.GetTokExcitationRulePointer().ForEach(p => gte.DrawPolygon(p.Pen, p.Triangle));
            _tokExcitationPanelVm.GetTokExcitationRuleFillPointer().ForEach(fp => gte.FillPolygon(fp.Brush, fp.Triangle));
            _tokExcitationPanelVm.GetTokExcitationRuleTokAnchorMeaningZone().ForEach(sp => gte.FillRectangle(sp.Brush, sp.LeftTopX, sp.LeftTopY, sp.Width, sp.Height));
            gte.Dispose();
            panel5.Invalidate();
        }

        private void UpdateDataBoxes(Parameters parameters)
        {
            _dataBoxVm.SolveDataBoxes(parameters);
            this.Invoke((MethodInvoker)delegate
                {
                    textBox1.Text = _dataBoxVm.GetDataBoxes()[0];
                    textBox2.Text = _dataBoxVm.GetDataBoxes()[1];
                    textBox3.Text = _dataBoxVm.GetDataBoxes()[2];
                    textBox4.Text = _dataBoxVm.GetDataBoxes()[3];
                    textBox5.Text = _dataBoxVm.GetDataBoxes()[4];
                });
        }

        private void UpdateLoadData(Parameters parameters)
        {
            _loadDataVm.SolveLoadData(parameters);
            this.Invoke((MethodInvoker)delegate
                {
                    richTextBox1.BackColor = _loadDataVm.GetLoadData()[0].BackColor;
                    richTextBox1.Text = _loadDataVm.GetLoadData()[0].Text;
                    richTextBox4.BackColor = _loadDataVm.GetLoadData()[3].BackColor;
                    richTextBox4.Text = _loadDataVm.GetLoadData()[3].Text;
                    richTextBox2.BackColor = _loadDataVm.GetLoadData()[1].BackColor;
                    richTextBox2.Text = _loadDataVm.GetLoadData()[1].Text;
                    richTextBox3.BackColor = _loadDataVm.GetLoadData()[2].BackColor;
                    richTextBox3.Text = _loadDataVm.GetLoadData()[2].Text;
                });
        }    

        private void UpdateParametersData(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab != tabPage6)
                return;
            var parametersSettingsVm = new ParametersSettingsVm();
            try
            {
                parametersSettingsVm.ReadFromFile(_mineConfig.ParametersConfig.ParametersFileName);
            }
            catch (Exception)
            {
                dataGridViewParameters.RowCount = 0;
                return;
            }
            this.Invoke((MethodInvoker)delegate
            {
                dataGridViewParameters.RowCount = parametersSettingsVm.ParametersSettingsDatas.Count;
                for (int i = 0; i < dataGridViewParameters.RowCount; i++)
                {
                    dataGridViewParameters[0, i].Value = i;
                    dataGridViewParameters[1, i].Value = "0x" + Convert.ToString(parametersSettingsVm.ParametersSettingsDatas[i].Id, 16); ;
                    dataGridViewParameters[2, i].Value = parametersSettingsVm.ParametersSettingsDatas[i].Name;
                    dataGridViewParameters[3, i].Value = parametersSettingsVm.ParametersSettingsDatas[i].Type;
                    dataGridViewParameters[4, i].Value = parametersSettingsVm.ParametersSettingsDatas[i].Value;
                }
            });
        }
        #endregion

        #region Handlers
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (btBac != null)
                    e.Graphics.DrawImage(btBac, 0, 0);
            }
            catch (Exception)
            {

            }    
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (btBac_two != null)
                    e.Graphics.DrawImage(btBac_two, 0, 0);
            }
            catch (Exception)
            {
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (btBac_dop != null)
                    e.Graphics.DrawImage(btBac_dop, 0, 0);
            }
            catch (Exception)
            {
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (btBac_two_dop != null)
                    e.Graphics.DrawImage(btBac_two_dop, 0, 0);
            }
            catch (Exception)
            {
            }         
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (btBac_speed != null)
                    e.Graphics.DrawImage(btBac_speed, 0, 0);
            }
            catch (Exception)
            {
            }         
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (btBac_tok_anchor != null)
                    e.Graphics.DrawImage(btBac_tok_anchor, 0, 0);
            }
            catch (Exception)
            {
            }

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (btBac_tok_excitation != null)
                    e.Graphics.DrawImage(btBac_tok_excitation, 0, 0);
            }
            catch (Exception)
            {
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            IoC.Resolve<FormSettingsParol>().ShowDialog();
            //new FormSettingsParol().Show();
        }
        private void buttonFind_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            new Thread(FindArhivThread){IsBackground = true}.Start();
        }

        private void FindArhivThread()
        {
            treeView1.Nodes.Clear();
            TreeNode[] nodeList = IoC.Resolve<ArhivVm>().GetNodesList(dateTimePicker1.Value, dateTimePicker2.Value);
            this.Invoke((MethodInvoker) delegate
            {
                treeView1.Nodes.AddRange(nodeList);
                textBoxRecordsCount.Text = IoC.Resolve<ArhivVm>().RecordsNum.ToString();
                if (IoC.Resolve<ArhivVm>().RecordsNum != 0)
                    textBoxCurrentRecord.Text = IoC.Resolve<ArhivVm>().CurrentId.ToString();
            });
        }
        private void buttonNext_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            treeView1.Nodes.AddRange(IoC.Resolve<ArhivVm>().GetNextNodesList());
            if (IoC.Resolve<ArhivVm>().RecordsNum != 0)
                textBoxCurrentRecord.Text = IoC.Resolve<ArhivVm>().CurrentId.ToString();
        }
        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            treeView1.Nodes.AddRange(IoC.Resolve<ArhivVm>().GetPrevNodesList());
            if (IoC.Resolve<ArhivVm>().RecordsNum != 0)
                textBoxCurrentRecord.Text = IoC.Resolve<ArhivVm>().CurrentId.ToString();
        }
        #endregion

        private LeftPanelVm _leftPanelVm;
        private RightPanelVm _rightPanelVm;
        private LeftDopPanelVm _leftDopPanelVm;
        private RightDopPanelVm _rightDopPanelVm;
        private SpeedPanelVm _speedPanelVm;
        private TokAnchorPanelVm _tokAnchorPanelVm;
        private TokExcitationPanelVm _tokExcitationPanelVm;
        private DataBoxVm _dataBoxVm;
        private LoadDataVm _loadDataVm;

        //user controls
        private CycleUC _cycleUc;
        private CepTpUC _cepTpUc;
        private AuziDUC _auziDUc;

        private DataBaseService _dataBaseService;
        private MineConfig _mineConfig;

        private DataListener _dataListener;
        private Bitmap btBac;
        private Bitmap btBac_two;
        private Bitmap btBac_dop;
        private Bitmap btBac_two_dop;
        private Bitmap btBac_speed;
        private Bitmap btBac_tok_anchor;
        private Bitmap btBac_tok_excitation;
        private int was_ostanov = 0;
        private int graphic_counter = 0;
        private int update_parameters_flag = 0;
        private int DefenceDiagramWorking = 0; //срабатывание защитной диаграм
        
        private Thread updateGraphicThread;
        private volatile Parameters _parameters = new Parameters();







    }
}
