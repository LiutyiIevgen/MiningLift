﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ML.ConfigSettings.Model;
using ML.ConfigSettings.Services;
using ML.DataExchange;
using ML.DataExchange.Model;
using VisualizationSystem.Model;
using VisualizationSystem.Model.Settings;
using VisualizationSystem.Services;
using VisualizationSystem.View.Forms;
using VisualizationSystem.View.Forms.Setting;
using VisualizationSystem.ViewModel;
using VisualizationSystem.ViewModel.MainViewModel;

namespace VisualizationSystem.View.UserControls
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
            _dataListener = IoC.Resolve<DataListener>();
            IoC.Resolve<CanStateService>().StartListener();
            _mineConfig = IoC.Resolve<MineConfig>();
        }
        public void MainView_Load()
        {
            CreateRichTextBoxMassiv();
            CreateAuziDIOSignalsMassiv();
            SetGraphicInterval(); 

            //view models creation чпап
            _leftPanelVm = new LeftPanelVm(panel1.Width, panel1.Height);
            _rightPanelVm = new RightPanelVm(panel2.Width, panel2.Height);
            _leftDopPanelVm = new LeftDopPanelVm(panel6.Width, panel6.Height);
            _rightDopPanelVm = new RightDopPanelVm(panel7.Width, panel7.Height);
            _speedPanelVm = new SpeedPanelVm(panel3.Width, panel3.Height);
            _tokAnchorPanelVm = new TokAnchorPanelVm(panel4.Width, panel4.Height);
            _tokExcitationPanelVm = new TokExcitationPanelVm(panel5.Width, panel5.Height);
            _centralSignalsDataVm = new CentralSignalsDataVm();
            _auziDInOutSignalsVm = new AuziDInOutSignalsVm();
            _loadDataVm = new LoadDataVm();
            _dataBoxVm = new DataBoxVm();

            //threads
            new Thread(UpdateLeftPanel){IsBackground = true}.Start();
            new Thread(UpdateRightPanel){IsBackground = true}.Start();
            new Thread(UpdateLeftDopPanel) { IsBackground = true }.Start();
            new Thread(UpdateRightDopPanel) { IsBackground = true }.Start();
            new Thread(UpdateSpeedPanel) { IsBackground = true }.Start();
            new Thread(UpdateTokAnchorPanel) { IsBackground = true }.Start();
            new Thread(UpdateTokExitationPanel) { IsBackground = true }.Start();
            new Thread(updateGraphicHandler) { IsBackground = true }.Start();
            new Thread(UpdateCentralSignalsData) { IsBackground = true }.Start();
            new Thread(UpdateAuziDInputOutputSignals) { IsBackground = true }.Start();

            _dataBaseService = IoC.Resolve<DataBaseService>();

            var param = new double[30];
            ViewData(new Parameters(param));

            _dataListener.Init(ViewData);
            var arhivWriterThread = new Thread(ArhivWriterThread){ IsBackground = true, Priority = ThreadPriority.Normal};
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
            /*Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();*/

            _updateLeftPanelFinished.WaitOne();
            _updateRightPanelFinished.WaitOne();
            _updateSpeedPanelFinished.WaitOne();
            _updateTokAnchorPanelFinished.WaitOne();
            _updateTokExitationPanelFinished.WaitOne();
            _updateLeftDopPanelFinished.WaitOne();
            _updateRightDopPanelFinished.WaitOne();

            _updateLeftPanelStart.Set();
            _updateRightPanelStart.Set();
            _updateSpeedPanelStart.Set();
            _updateTokAnchorPanelStart.Set();
            _updateTokExitationPanelStart.Set();
            _updateLeftDopPanelStart.Set();
            _updateRightDopPanelStart.Set();
            

            UpdateDataBoxes(parameters);
            UpdateLoadData(parameters);


            /*if (update_parameters_flag%10 == 0)
            {
                _updateGraphicFinished.WaitOne();
                _updateGraphicStart.Set();
            }
            if (update_parameters_flag%20 == 0)
            {
                _updateCentralSignalsFinished.WaitOne();
                _updateAuziDInputOutputFinished.WaitOne();
                _updateCentralSignalsStart.Set();
                _updateAuziDInputOutputStart.Set();
                update_parameters_flag = 0;
            }
            update_parameters_flag++;*/
            /*stopwatch.Stop();
            stopwatch = null;*/
        }

        #region Threads
        private void ArhivWriterThread()
        {
            while (true)
            {
                if (_mineConfig.MainViewConfig.ArchiveState == ArchiveState.Active)
                    _dataBaseService.FillDataBase(_parameters);
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

        private void updateGraphicHandler()
        {
            while (true)
            {
                _updateGraphicStart.WaitOne();
                if (_parameters.f_ostanov == 1)
                    was_ostanov = 1;
                if (_parameters.f_start == 1 || _parameters.f_back == 1)
                {
                    //var defenceDiagramVm = new DefenceDiagramVm(param);
                    if (chartVA.Series[0].Points.Count == 500)
                    {
                        this.Invoke((MethodInvoker) delegate
                        {
                            chartVA.Series[0].Points.Clear();
                            chartVA.Series[1].Points.Clear();
                            chartVA.Series[2].Points.Clear();
                            //chartVA.Series[3].Points.Clear();
                        });
                        was_ostanov = 0;
                    }
                    this.Invoke((MethodInvoker) delegate
                    {
                        chartVA.Series[0].Points.AddXY(-_parameters.s,
                            _parameters.v/(_mineConfig.MainViewConfig.MaxSpeed.Value/100));
                        chartVA.Series[1].Points.AddXY(-_parameters.s,
                            _parameters.tok_anchor/(_mineConfig.MainViewConfig.MaxTokAnchor.Value/100));
                        chartVA.Series[2].Points.AddXY(-_parameters.s,
                            _parameters.tok_excitation/(_mineConfig.MainViewConfig.MaxTokExcitation.Value/100));
                        /*chartVA.Series[3].Points.Clear();
                    for (int i = 0; i < defenceDiagramVm.CurrentDiagram.Count(); i++)
                    {
                        chartVA.Series[3].Points.AddXY(-defenceDiagramVm.CurrentDiagram[i].X,
                            defenceDiagramVm.CurrentDiagram[i].Y /
                            (_mineConfig.MainViewConfig.MaxSpeed.Value / 100));
                    }*/
                        int j = 0;
                        foreach (object item in checkedListBoxGraphic.Items)
                        {
                            chartVA.Series[j].Enabled = checkedListBoxGraphic.CheckedItems.Contains(item);
                            j++;
                        }
                    });
                }
                _updateGraphicFinished.Set();
            }
        }
        #endregion

        #region ViewModel binding
        private void SetGraphicInterval()
        {
            this.Invoke((MethodInvoker)delegate
            {
                chartVA.ChartAreas[0].AxisX.Maximum = Settings.UpZeroZone;
                chartVA.ChartAreas[0].AxisX.Minimum = -(_mineConfig.MainViewConfig.Distance.Value + _mineConfig.MainViewConfig.Distance.Value / 8 - Settings.UpZeroZone);
                chartVA.ChartAreas[0].AxisX.Interval = _mineConfig.MainViewConfig.Distance.Value / 8;
                chartVA.ChartAreas[0].AxisY.Minimum = -100;
                chartVA.ChartAreas[0].AxisY.Maximum = 125;
                chartVA.ChartAreas[0].AxisY.Interval = 25;
            });
        }

        private void CreateRichTextBoxMassiv()
        {
            masRichTextBox = new RichTextBox[] { richTextBox5, richTextBox6, richTextBox7, richTextBox8, 
                richTextBox9, richTextBox10, richTextBox11, richTextBox12,
                richTextBox13, richTextBox14, richTextBox15, richTextBox16,
                richTextBox17, richTextBox18, richTextBox19, richTextBox20, richTextBox21,
                richTextBox22, richTextBox23, richTextBox24, richTextBox25, richTextBox26, 
                richTextBox27, richTextBox28};
            for (int i = 0; i < checkedListBoxGraphic.Items.Count; i++)
                checkedListBoxGraphic.SetItemChecked(i, true);
        }

        private void CreateAuziDIOSignalsMassiv()
        {
            masInTextBox = new TextBox[] { textBox6, textBox7, textBox8, textBox9, 
                textBox10, textBox11, textBox12, textBox13, textBox14, textBox15,
                textBox16, textBox17, textBox18, textBox19, textBox20, textBox21,
                textBox22, textBox23, textBox24, textBox25, textBox26, textBox27,
                textBox28, textBox29, textBox30, textBox31, textBox32, textBox33,
                textBox34, textBox35, textBox36, textBox37 };

            masOutTextBox = new TextBox[] { textBox38, textBox39, textBox40, textBox41, 
                textBox42, textBox43, textBox44, textBox45, textBox46, textBox47, textBox48,
                textBox49, textBox50, textBox51, textBox52, textBox53 };


            masInLabel = new Label[] { label4, label5, label11, label12, label13, label14, label15,
                label16, label17, label18, label19, label20, label21, label22, label23, label24,
                label25, label26, label27, label28, label29, label30, label31, label32, label33,
                label34, label35, label36, label37, label38, label39, label40};

            masOutLabel = new Label[] { label41, label42, label43, label44, label45, label46,
                label47, label48, label49, label50, label51, label52, label53, label54, label55, label56 };
        }

        

        private void UpdateLeftPanel()
        {
            while (true)
            {
                _updateLeftPanelStart.WaitOne();
                btBac = new Bitmap(panel1.Width, panel1.Height); // панель клети
                Graphics g = Graphics.FromImage(btBac);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                _leftPanelVm.InitVm(_parameters);
                _leftPanelVm.GetMainRuleDatas().ForEach(l => g.DrawLine(l.Pen, l.FirstPoint, l.SecondPoint));
                _leftPanelVm.GetMainRuleInscription().ForEach(s => g.DrawString(s.Text, s.Font, s.Brush, s.Position));
                _leftPanelVm.GetMainRuleZones()
                    .ForEach(z => g.FillRectangle(z.Brush, z.LeftTopX, z.LeftTopY, z.Width, z.Height));
                if (_mineConfig.MainViewConfig.LeftSosud == SosudType.Skip)
                    _leftPanelVm.GetMainRulePointerLineSkip()
                        .ForEach(pl => g.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
                else
                    _leftPanelVm.GetMainRulePointerLineBackBalance()
                        .ForEach(pl => g.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
                _leftPanelVm.GetMainRulePointer().ForEach(p => g.DrawPolygon(p.Pen, p.Triangle));
                _leftPanelVm.GetMainRuleFillPointer().ForEach(fp => g.FillPolygon(fp.Brush, fp.Triangle));
                _leftPanelVm.GetMainRuleCage()
                    .ForEach(c => g.FillRectangle(c.Brush, c.LeftTopX, c.LeftTopY, c.Width, c.Height));
                if (_mineConfig.MainViewConfig.LeftSosud == SosudType.Skip)
                    _leftPanelVm.GetMainRuleDirectionPointerSkip().ForEach(dp => g.DrawPolygon(dp.Pen, dp.Triangle));
                else
                    _leftPanelVm.GetMainRuleDirectionPointerBackBalance()
                        .ForEach(dp => g.DrawPolygon(dp.Pen, dp.Triangle));
                _leftPanelVm.GetMainRuleDirectionFillPointer().ForEach(dfp => g.FillPolygon(dfp.Brush, dfp.Triangle));
                g.Dispose();
                panel1.Invalidate();
                _updateLeftPanelFinished.Set();
            }
        }

        private void UpdateRightPanel()
        {
            while (true)
            {
                _updateRightPanelStart.WaitOne();
                btBac_two = new Bitmap(panel2.Width, panel2.Height); // панель противовеса
                Graphics gr = Graphics.FromImage(btBac_two);
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                _rightPanelVm.InitVm(_parameters);
                _rightPanelVm.GetMainRuleDatas().ForEach(l => gr.DrawLine(l.Pen, l.FirstPoint, l.SecondPoint));
                _rightPanelVm.GetMainRuleInscription().ForEach(s => gr.DrawString(s.Text, s.Font, s.Brush, s.Position));
                _rightPanelVm.GetMainRuleZones()
                    .ForEach(z => gr.FillRectangle(z.Brush, z.LeftTopX, z.LeftTopY, z.Width, z.Height));
                if (_mineConfig.MainViewConfig.RightSosud == SosudType.Skip)
                    _rightPanelVm.GetMainRulePointerLineSkip()
                        .ForEach(pl => gr.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
                else
                    _rightPanelVm.GetMainRulePointerLineBackBalance()
                        .ForEach(pl => gr.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
                _rightPanelVm.GetMainRulePointer().ForEach(p => gr.DrawPolygon(p.Pen, p.Triangle));
                _rightPanelVm.GetMainRuleFillPointer().ForEach(fp => gr.FillPolygon(fp.Brush, fp.Triangle));
                _rightPanelVm.GetMainRuleCage()
                    .ForEach(c => gr.FillRectangle(c.Brush, c.LeftTopX, c.LeftTopY, c.Width, c.Height));
                if (_mineConfig.MainViewConfig.RightSosud == SosudType.Skip)
                    _rightPanelVm.GetMainRuleDirectionPointerSkip().ForEach(dp => gr.DrawPolygon(dp.Pen, dp.Triangle));
                else
                    _rightPanelVm.GetMainRuleDirectionPointerBackBalance()
                        .ForEach(dp => gr.DrawPolygon(dp.Pen, dp.Triangle));
                _rightPanelVm.GetMainRuleDirectionFillPointer().ForEach(dfp => gr.FillPolygon(dfp.Brush, dfp.Triangle));
                gr.Dispose();
                panel2.Invalidate();
                _updateRightPanelFinished.Set();
            }
        }

        private void UpdateLeftDopPanel()
        {
            while (true)
            {
                _updateLeftDopPanelStart.WaitOne();
                btBac_dop = new Bitmap(panel6.Width, panel6.Height); // панель дополнительной шккалы клети
                Graphics gd = Graphics.FromImage(btBac_dop);
                gd.SmoothingMode = SmoothingMode.AntiAlias;

                _leftDopPanelVm.InitVm(_parameters);
                _leftDopPanelVm.GetDopRuleDatas().ForEach(l => gd.DrawLine(l.Pen, l.FirstPoint, l.SecondPoint));
                _leftDopPanelVm.GetDopRuleInscription().ForEach(s => gd.DrawString(s.Text, s.Font, s.Brush, s.Position));
                _leftDopPanelVm.GetDopRulePointerLine()
                    .ForEach(pl => gd.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
                _leftDopPanelVm.GetDopRulePointer().ForEach(p => gd.DrawPolygon(p.Pen, p.Triangle));
                _leftDopPanelVm.GetDopRuleFillPointer().ForEach(fp => gd.FillPolygon(fp.Brush, fp.Triangle));
                _leftDopPanelVm.GetDopRulePanelBorderLine()
                    .ForEach(c => gd.DrawRectangle(c.Pen, c.LeftTopX, c.LeftTopY, c.Width, c.Height));
                gd.Dispose();
                panel6.Invalidate();
                _updateLeftDopPanelFinished.Set();
            }
        }

        private void UpdateRightDopPanel()
        {
            while (true)
            {
                _updateRightDopPanelStart.WaitOne();
                btBac_two_dop = new Bitmap(panel7.Width, panel7.Height); // панель дополнительной шкалы пртивовеса
                Graphics grd = Graphics.FromImage(btBac_two_dop);
                grd.SmoothingMode = SmoothingMode.AntiAlias;

                _rightDopPanelVm.InitVm(_parameters);
                _rightDopPanelVm.GetDopRuleDatas().ForEach(l => grd.DrawLine(l.Pen, l.FirstPoint, l.SecondPoint));
                _rightDopPanelVm.GetDopRuleInscription()
                    .ForEach(s => grd.DrawString(s.Text, s.Font, s.Brush, s.Position));
                _rightDopPanelVm.GetDopRulePointerLine()
                    .ForEach(pl => grd.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
                _rightDopPanelVm.GetDopRulePointer().ForEach(p => grd.DrawPolygon(p.Pen, p.Triangle));
                _rightDopPanelVm.GetDopRuleFillPointer().ForEach(fp => grd.FillPolygon(fp.Brush, fp.Triangle));
                _rightDopPanelVm.GetDopRulePanelBorderLine()
                    .ForEach(c => grd.DrawRectangle(c.Pen, c.LeftTopX, c.LeftTopY, c.Width, c.Height));
                grd.Dispose();
                panel7.Invalidate();
                _updateRightDopPanelFinished.Set();
            }
        }

        private void UpdateSpeedPanel()
        {
            while (true)
            {
                _updateSpeedPanelStart.WaitOne();
                btBac_speed = new Bitmap(panel3.Width, panel3.Height); // панель скорости
                Graphics gs = Graphics.FromImage(btBac_speed);
                gs.SmoothingMode = SmoothingMode.AntiAlias;

                _speedPanelVm.InitVm(_parameters);
                _speedPanelVm.GetSpeedRuleDatas().ForEach(l => gs.DrawLine(l.Pen, l.FirstPoint, l.SecondPoint));
                _speedPanelVm.GetSpeedRuleInscription().ForEach(s => gs.DrawString(s.Text, s.Font, s.Brush, s.Position));
                _speedPanelVm.GetSpeedRulePointerLine()
                    .ForEach(pl => gs.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
                _speedPanelVm.GetSpeedRulePointer().ForEach(p => gs.DrawPolygon(p.Pen, p.Triangle));
                _speedPanelVm.GetSpeedRuleFillPointer().ForEach(fp => gs.FillPolygon(fp.Brush, fp.Triangle));
                _speedPanelVm.GetSpeedRuleSpeedMeaningZone()
                    .ForEach(sp => gs.FillRectangle(sp.Brush, sp.LeftTopX, sp.LeftTopY, sp.Width, sp.Height));
                gs.Dispose();
                panel3.Invalidate();
                _updateSpeedPanelFinished.Set();
            }
        }

        private void UpdateTokAnchorPanel()
        {
            while (true)
            {
                _updateTokAnchorPanelStart.WaitOne();
                btBac_tok_anchor = new Bitmap(panel4.Width, panel4.Height); // панель тока якоря
                Graphics gta = Graphics.FromImage(btBac_tok_anchor);
                gta.SmoothingMode = SmoothingMode.AntiAlias;

                _tokAnchorPanelVm.InitVm(_parameters);
                _tokAnchorPanelVm.GetTokAnchorRuleDatas().ForEach(l => gta.DrawLine(l.Pen, l.FirstPoint, l.SecondPoint));
                _tokAnchorPanelVm.GetTokAnchorRuleInscription()
                    .ForEach(s => gta.DrawString(s.Text, s.Font, s.Brush, s.Position));
                _tokAnchorPanelVm.GetTokAnchorRulePointerLine()
                    .ForEach(pl => gta.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
                _tokAnchorPanelVm.GetTokAnchorRulePointer().ForEach(p => gta.DrawPolygon(p.Pen, p.Triangle));
                _tokAnchorPanelVm.GetTokAnchorRuleFillPointer().ForEach(fp => gta.FillPolygon(fp.Brush, fp.Triangle));
                _tokAnchorPanelVm.GetTokAnchorRuleTokAnchorMeaningZone()
                    .ForEach(sp => gta.FillRectangle(sp.Brush, sp.LeftTopX, sp.LeftTopY, sp.Width, sp.Height));
                gta.Dispose();
                panel4.Invalidate();
                _updateTokAnchorPanelFinished.Set();
            }
        }

        private void UpdateTokExitationPanel()
        {
            while (true)
            {
                _updateTokExitationPanelStart.WaitOne();
                btBac_tok_excitation = new Bitmap(panel5.Width, panel5.Height); // панель тока возбуждения
                Graphics gte = Graphics.FromImage(btBac_tok_excitation);
                gte.SmoothingMode = SmoothingMode.AntiAlias;

                _tokExcitationPanelVm.InitVm(_parameters);
                _tokExcitationPanelVm.GetTokExcitationRuleDatas()
                    .ForEach(l => gte.DrawLine(l.Pen, l.FirstPoint, l.SecondPoint));
                _tokExcitationPanelVm.GetTokExcitationRuleInscription()
                    .ForEach(s => gte.DrawString(s.Text, s.Font, s.Brush, s.Position));
                _tokExcitationPanelVm.GetTokExcitationRulePointerLine()
                    .ForEach(pl => gte.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
                _tokExcitationPanelVm.GetTokExcitationRulePointer().ForEach(p => gte.DrawPolygon(p.Pen, p.Triangle));
                _tokExcitationPanelVm.GetTokExcitationRuleFillPointer()
                    .ForEach(fp => gte.FillPolygon(fp.Brush, fp.Triangle));
                _tokExcitationPanelVm.GetTokExcitationRuleTokAnchorMeaningZone()
                    .ForEach(sp => gte.FillRectangle(sp.Brush, sp.LeftTopX, sp.LeftTopY, sp.Width, sp.Height));
                gte.Dispose();
                panel5.Invalidate();
                _updateTokExitationPanelFinished.Set();
            }
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


        private void UpdateCentralSignalsData()
        {
            while (true)
            {
                _updateCentralSignalsStart.WaitOne();
                var centralSignals = _centralSignalsDataVm.GetSignalsData(_parameters);
                this.Invoke((MethodInvoker) delegate
                {
                    for (int i = 0; i < 24; i++)
                    {
                        masRichTextBox[i].BackColor = centralSignals[i].BackColor;
                        masRichTextBox[i].Text = centralSignals[i].Text;
                    }
                });
                if (centralSignals[11].BackColor == Color.Red && DefenceDiagramWorking == 0)
                {
                    this.Invoke((MethodInvoker) delegate
                    {
                        tabControl1.SelectedIndex = 1;
                    });
                    DefenceDiagramWorking = 1;
                }
                if (centralSignals[11].BackColor == Color.DarkGray && DefenceDiagramWorking == 1)
                {
                    DefenceDiagramWorking = 0;
                }
                _updateCentralSignalsFinished.Set();
            }
        }

        private void UpdateAuziDInputOutputSignals()
        {
            while (true)
            {
                _updateAuziDInputOutputStart.WaitOne();
                _auziDInOutSignalsVm.UpDateSignals(_parameters);
                this.Invoke((MethodInvoker) delegate
                {
                    for (int i = 0; i < 32; i++)
                    {
                        masInTextBox[i].BackColor = _auziDInOutSignalsVm.InputMeanings[i];
                        masInLabel[i].Text = _auziDInOutSignalsVm.InputNames[i];
                    }
                    for (int i = 0; i < 16; i++)
                    {
                        masOutTextBox[i].BackColor = _auziDInOutSignalsVm.OutputMeanings[i];
                        masOutLabel[i].Text = _auziDInOutSignalsVm.OutputNames[i];
                    }
                });
                _updateAuziDInputOutputFinished.Set();
            }
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
        private CentralSignalsDataVm _centralSignalsDataVm;
        private AuziDInOutSignalsVm _auziDInOutSignalsVm;
        private DataBoxVm _dataBoxVm;
        private LoadDataVm _loadDataVm;

        //event hanlers fo threads
        EventWaitHandle _updateLeftPanelStart = new AutoResetEvent(false);
        EventWaitHandle _updateRightPanelStart = new AutoResetEvent(false);
        EventWaitHandle _updateLeftDopPanelStart = new AutoResetEvent(false);
        EventWaitHandle _updateRightDopPanelStart = new AutoResetEvent(false);
        EventWaitHandle _updateSpeedPanelStart = new AutoResetEvent(false);
        EventWaitHandle _updateTokAnchorPanelStart = new AutoResetEvent(false);
        EventWaitHandle _updateTokExitationPanelStart = new AutoResetEvent(false);
        EventWaitHandle _updateCentralSignalsStart = new AutoResetEvent(false);
        EventWaitHandle _updateAuziDInputOutputStart = new AutoResetEvent(false);
        EventWaitHandle _updateGraphicStart = new AutoResetEvent(false);

        EventWaitHandle _updateLeftPanelFinished = new AutoResetEvent(true);
        EventWaitHandle _updateRightPanelFinished = new AutoResetEvent(true);
        EventWaitHandle _updateLeftDopPanelFinished = new AutoResetEvent(true);
        EventWaitHandle _updateRightDopPanelFinished = new AutoResetEvent(true);
        EventWaitHandle _updateSpeedPanelFinished = new AutoResetEvent(true);
        EventWaitHandle _updateTokAnchorPanelFinished = new AutoResetEvent(true);
        EventWaitHandle _updateTokExitationPanelFinished = new AutoResetEvent(true);
        EventWaitHandle _updateCentralSignalsFinished = new AutoResetEvent(true);
        EventWaitHandle _updateAuziDInputOutputFinished = new AutoResetEvent(true);
        EventWaitHandle _updateGraphicFinished = new AutoResetEvent(true);

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
        private int DefenceDiagramWorking = 0; //срабатывание защитной диаграммы
        private RichTextBox[] masRichTextBox;//массив текстбоксов для вывода сигналов цунтральной части экрана
        private TextBox[] masInTextBox;//массив текстбоксов для вывода входных сигналов АУЗИ-Д
        private Label[] masInLabel;//массив лейблов для вывода входных сигналов АУЗИ-Д
        private TextBox[] masOutTextBox;//массив текстбоксов для вывода выходных сигналов АУЗИ-Д
        private Label[] masOutLabel;//массив лейблов для вывода выходных сигналов АУЗИ-Д
        private volatile Parameters _parameters = new Parameters();







    }
}
