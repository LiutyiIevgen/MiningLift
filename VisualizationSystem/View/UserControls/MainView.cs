using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ML.ConfigSettings.Model;
using ML.ConfigSettings.Services;
using ML.DataExchange;
using ML.DataExchange.Model;
using VisualizationSystem.Model;
using VisualizationSystem.Services;
using VisualizationSystem.View.Forms;
using VisualizationSystem.View.Forms.Setting;
using VisualizationSystem.ViewModel;

namespace VisualizationSystem.View.UserControls
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
            _dataListener = IoC.Resolve<DataListener>();
        }
        public void MainView_Load()
        {
            CreateRichTextBoxMassiv();
            CreateAuziDIOSignalsMassiv();
            SetGraphicInterval();
            updateGraphicThread = new Thread(updateGraphicHandler);
            updateGraphicThread.IsBackground = true;
            var param = new double[30];
            ViewData(new Parameters(param));
            //ViewData(new Parameters(param));
            _dataListener.Init(ViewData);
           // string[] s = IoC.Resolve<MineConfig>().AuziDSignalsConfig.AddedSignals;
           // s[0] = "1";
           // IoC.Resolve<MineConfig>().AuziDSignalsConfig.AddedSignals = s;
        }

        public void ViewData(Parameters parameters)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    labelTime.Text = DateTime.Now.ToLongTimeString();
                    labelDate.Text = DateTime.Now.ToShortDateString();
                });
            }
            catch(Exception)
            {
                return;
            }
            //
            Settings.UpZeroZone = IoC.Resolve<MineConfig>().MainViewConfig.UpZeroZone.Value;
            //
            UpdateLeftPanel(parameters);
            UpdateRightPanel(parameters);
            UpdateLeftDopPanel(parameters);
            UpdateRightDopPanel(parameters);
            UpdateSpeedPanel(parameters);
            UpdateTokAnchorPanel(parameters);
            UpdateTokExitationPanel(parameters);

            UpdateDataBoxes(parameters);
            UpdateLoadData(parameters);
            UpdateCentralSignalsData(parameters);
            UpdateAuziDInputOutputSignals(parameters);
            if (update_parameters_flag%10==0)
            if (!updateGraphicThread.IsAlive)
            {
                updateGraphicThread = new Thread(updateGraphicHandler);
                updateGraphicThread.IsBackground = true;
                updateGraphicThread.Start(parameters);
            }
                
            update_parameters_flag++;
            if (update_parameters_flag%10 == 0)
            {
                UpdateParametersData();
                update_parameters_flag = 0;
            }
        }

        private void SetGraphicInterval()
        {
            this.Invoke((MethodInvoker)delegate
            {
                chartVA.ChartAreas[0].AxisX.Maximum = Settings.UpZeroZone;
                chartVA.ChartAreas[0].AxisX.Minimum = -(IoC.Resolve<MineConfig>().MainViewConfig.Distance.Value + IoC.Resolve<MineConfig>().MainViewConfig.Distance.Value / 8 - Settings.UpZeroZone);
                chartVA.ChartAreas[0].AxisX.Interval = IoC.Resolve<MineConfig>().MainViewConfig.Distance.Value / 8;
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

        private void updateGraphicHandler(object parameters)
        {
                var param = parameters as Parameters;
                if (param.f_ostanov == 1)
                    was_ostanov = 1;
                if (param.f_start == 1 || param.f_back == 1)
                {
                    //var defenceDiagramVm = new DefenceDiagramVm(param);
                    if (chartVA.Series[0].Points.Count==700)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            chartVA.Series[0].Points.Clear();
                            chartVA.Series[1].Points.Clear();
                            chartVA.Series[2].Points.Clear();
                            //chartVA.Series[3].Points.Clear();
                        });
                        was_ostanov = 0;
                    }
                    this.Invoke((MethodInvoker)delegate
                    {
                        chartVA.Series[0].Points.AddXY(-param.s,
                            param.v / (IoC.Resolve<MineConfig>().MainViewConfig.MaxSpeed.Value / 100));
                        chartVA.Series[1].Points.AddXY(-param.s,
                            param.tok_anchor / (IoC.Resolve<MineConfig>().MainViewConfig.MaxTokAnchor.Value / 100));
                        chartVA.Series[2].Points.AddXY(-param.s,
                            param.tok_excitation / (IoC.Resolve<MineConfig>().MainViewConfig.MaxTokExcitation.Value / 100));
                        /*chartVA.Series[3].Points.Clear();
                        for (int i = 0; i < defenceDiagramVm.CurrentDiagram.Count(); i++)
                        {
                            chartVA.Series[3].Points.AddXY(-defenceDiagramVm.CurrentDiagram[i].X,
                                defenceDiagramVm.CurrentDiagram[i].Y /
                                (IoC.Resolve<MineConfig>().MainViewConfig.MaxSpeed.Value / 100));
                        }*/
                    });
            }
        }

        private void UpdateLeftPanel(Parameters parameters)
        {
            btBac = new Bitmap(panel1.Width, panel1.Height); // панель клети
            Graphics g = Graphics.FromImage(btBac);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var leftPanelVm = new LeftPanelVm(panel1.Width, panel1.Height, parameters);
            leftPanelVm.GetMainRuleDatas().ForEach(l => g.DrawLine(l.Pen, l.FirstPoint, l.SecondPoint));
            leftPanelVm.GetMainRuleInscription().ForEach(s => g.DrawString(s.Text, s.Font, s.Brush, s.Position));
            leftPanelVm.GetMainRuleZones().ForEach(z => g.FillRectangle(z.Brush, z.LeftTopX, z.LeftTopY, z.Width, z.Height));
            if (IoC.Resolve<MineConfig>().MainViewConfig.LeftSosud == SosudType.Skip)
                leftPanelVm.GetMainRulePointerLineSkip().ForEach(pl => g.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
            else
                leftPanelVm.GetMainRulePointerLineBackBalance().ForEach(pl => g.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
            leftPanelVm.GetMainRulePointer().ForEach(p => g.DrawPolygon(p.Pen, p.Triangle));
            leftPanelVm.GetMainRuleFillPointer().ForEach(fp => g.FillPolygon(fp.Brush, fp.Triangle));
            leftPanelVm.GetMainRuleCage().ForEach(c => g.FillRectangle(c.Brush, c.LeftTopX, c.LeftTopY, c.Width, c.Height));
            if (IoC.Resolve<MineConfig>().MainViewConfig.LeftSosud == SosudType.Skip)
                leftPanelVm.GetMainRuleDirectionPointerSkip().ForEach(dp => g.DrawPolygon(dp.Pen, dp.Triangle));
            else
                leftPanelVm.GetMainRuleDirectionPointerBackBalance().ForEach(dp => g.DrawPolygon(dp.Pen, dp.Triangle));
            leftPanelVm.GetMainRuleDirectionFillPointer().ForEach(dfp => g.FillPolygon(dfp.Brush, dfp.Triangle));
            leftPanelVm.DisposeDrawingAttributes();
            g.Dispose();
            panel1.Invalidate();
        }

        private void UpdateRightPanel(Parameters parameters)
        {
            btBac_two = new Bitmap(panel2.Width, panel2.Height); // панель противовеса
            Graphics gr = Graphics.FromImage(btBac_two);
            gr.SmoothingMode = SmoothingMode.AntiAlias;

            var rightPanelVm = new RightPanelVm(panel2.Width, panel2.Height, parameters);
            rightPanelVm.GetMainRuleDatas().ForEach(l => gr.DrawLine(l.Pen, l.FirstPoint, l.SecondPoint));
            rightPanelVm.GetMainRuleInscription().ForEach(s => gr.DrawString(s.Text, s.Font, s.Brush, s.Position));
            rightPanelVm.GetMainRuleZones().ForEach(z => gr.FillRectangle(z.Brush, z.LeftTopX, z.LeftTopY, z.Width, z.Height));
            if (IoC.Resolve<MineConfig>().MainViewConfig.RightSosud == SosudType.Skip)
                rightPanelVm.GetMainRulePointerLineSkip().ForEach(pl => gr.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
            else
                rightPanelVm.GetMainRulePointerLineBackBalance().ForEach(pl => gr.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
            rightPanelVm.GetMainRulePointer().ForEach(p => gr.DrawPolygon(p.Pen, p.Triangle));
            rightPanelVm.GetMainRuleFillPointer().ForEach(fp => gr.FillPolygon(fp.Brush, fp.Triangle));
            rightPanelVm.GetMainRuleCage().ForEach(c => gr.FillRectangle(c.Brush, c.LeftTopX, c.LeftTopY, c.Width, c.Height));
            if (IoC.Resolve<MineConfig>().MainViewConfig.RightSosud == SosudType.Skip)
                rightPanelVm.GetMainRuleDirectionPointerSkip().ForEach(dp => gr.DrawPolygon(dp.Pen, dp.Triangle));
            else
                rightPanelVm.GetMainRuleDirectionPointerBackBalance().ForEach(dp => gr.DrawPolygon(dp.Pen, dp.Triangle));
            rightPanelVm.GetMainRuleDirectionFillPointer().ForEach(dfp => gr.FillPolygon(dfp.Brush, dfp.Triangle));
            rightPanelVm.DisposeDrawingAttributes();
            gr.Dispose();
            panel2.Invalidate();
        }

        private void UpdateLeftDopPanel(Parameters parameters)
        {
            btBac_dop = new Bitmap(panel6.Width, panel6.Height); // панель дополнительной шккалы клети
            Graphics gd = Graphics.FromImage(btBac_dop);
            gd.SmoothingMode = SmoothingMode.AntiAlias;

            var leftDopPanelVm = new LeftDopPanelVm(panel6.Width, panel6.Height, parameters);
            leftDopPanelVm.GetDopRuleDatas().ForEach(l => gd.DrawLine(l.Pen, l.FirstPoint, l.SecondPoint));
            leftDopPanelVm.GetDopRuleInscription().ForEach(s => gd.DrawString(s.Text, s.Font, s.Brush, s.Position));
            leftDopPanelVm.GetDopRulePointerLine().ForEach(pl => gd.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
            leftDopPanelVm.GetDopRulePointer().ForEach(p => gd.DrawPolygon(p.Pen, p.Triangle));
            leftDopPanelVm.GetDopRuleFillPointer().ForEach(fp => gd.FillPolygon(fp.Brush, fp.Triangle));
            leftDopPanelVm.GetDopRulePanelBorderLine().ForEach(c => gd.DrawRectangle(c.Pen, c.LeftTopX, c.LeftTopY, c.Width, c.Height));
            leftDopPanelVm.DisposeDrawingAttributes();
            gd.Dispose();
            panel6.Invalidate();
        }

        private void UpdateRightDopPanel(Parameters parameters)
        {
            btBac_two_dop = new Bitmap(panel7.Width, panel7.Height); // панель дополнительной шкалы пртивовеса
            Graphics grd = Graphics.FromImage(btBac_two_dop);
            grd.SmoothingMode = SmoothingMode.AntiAlias;

            var rightDopPanelVm = new RightDopPanelVm(panel7.Width, panel7.Height, parameters);
            rightDopPanelVm.GetDopRuleDatas().ForEach(l => grd.DrawLine(l.Pen, l.FirstPoint, l.SecondPoint));
            rightDopPanelVm.GetDopRuleInscription().ForEach(s => grd.DrawString(s.Text, s.Font, s.Brush, s.Position));
            rightDopPanelVm.GetDopRulePointerLine().ForEach(pl => grd.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
            rightDopPanelVm.GetDopRulePointer().ForEach(p => grd.DrawPolygon(p.Pen, p.Triangle));
            rightDopPanelVm.GetDopRuleFillPointer().ForEach(fp => grd.FillPolygon(fp.Brush, fp.Triangle));
            rightDopPanelVm.GetDopRulePanelBorderLine().ForEach(c => grd.DrawRectangle(c.Pen, c.LeftTopX, c.LeftTopY, c.Width, c.Height));
            rightDopPanelVm.DisposeDrawingAttributes();
            grd.Dispose();
            panel7.Invalidate();
        }

        private void UpdateSpeedPanel(Parameters parameters)
        {
            btBac_speed = new Bitmap(panel3.Width, panel3.Height); // панель скорости
            Graphics gs = Graphics.FromImage(btBac_speed);
            gs.SmoothingMode = SmoothingMode.AntiAlias;

            var speedPanelVm = new SpeedPanelVm(panel3.Width, panel3.Height, parameters);
            speedPanelVm.GetSpeedRuleDatas().ForEach(l => gs.DrawLine(l.Pen, l.FirstPoint, l.SecondPoint));
            speedPanelVm.GetSpeedRuleInscription().ForEach(s => gs.DrawString(s.Text, s.Font, s.Brush, s.Position));
            speedPanelVm.GetSpeedRulePointerLine().ForEach(pl => gs.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
            speedPanelVm.GetSpeedRulePointer().ForEach(p => gs.DrawPolygon(p.Pen, p.Triangle));
            speedPanelVm.GetSpeedRuleFillPointer().ForEach(fp => gs.FillPolygon(fp.Brush, fp.Triangle));
            speedPanelVm.GetSpeedRuleSpeedMeaningZone().ForEach(sp => gs.FillRectangle(sp.Brush, sp.LeftTopX, sp.LeftTopY, sp.Width, sp.Height));
            speedPanelVm.DisposeDrawingAttributes();
            gs.Dispose();
            panel3.Invalidate();
        }

        private void UpdateTokAnchorPanel(Parameters parameters)
        {
            btBac_tok_anchor = new Bitmap(panel4.Width, panel4.Height); // панель тока якоря
            Graphics gta = Graphics.FromImage(btBac_tok_anchor);
            gta.SmoothingMode = SmoothingMode.AntiAlias;

            var tokAnchorPanelVm = new TokAnchorPanelVm(panel4.Width, panel4.Height, parameters);
            tokAnchorPanelVm.GetTokAnchorRuleDatas().ForEach(l => gta.DrawLine(l.Pen, l.FirstPoint, l.SecondPoint));
            tokAnchorPanelVm.GetTokAnchorRuleInscription().ForEach(s => gta.DrawString(s.Text, s.Font, s.Brush, s.Position));
            tokAnchorPanelVm.GetTokAnchorRulePointerLine().ForEach(pl => gta.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
            tokAnchorPanelVm.GetTokAnchorRulePointer().ForEach(p => gta.DrawPolygon(p.Pen, p.Triangle));
            tokAnchorPanelVm.GetTokAnchorRuleFillPointer().ForEach(fp => gta.FillPolygon(fp.Brush, fp.Triangle));
            tokAnchorPanelVm.GetTokAnchorRuleTokAnchorMeaningZone().ForEach(sp => gta.FillRectangle(sp.Brush, sp.LeftTopX, sp.LeftTopY, sp.Width, sp.Height));
            tokAnchorPanelVm.DisposeDrawingAttributes();
            gta.Dispose();
            panel4.Invalidate();
        }

        private void UpdateTokExitationPanel(Parameters parameters)
        {
            btBac_tok_excitation = new Bitmap(panel5.Width, panel5.Height); // панель тока возбуждения
            Graphics gte = Graphics.FromImage(btBac_tok_excitation);
            gte.SmoothingMode = SmoothingMode.AntiAlias;

            var tokExcitationPanelVm = new TokExcitationPanelVm(panel5.Width, panel5.Height, parameters);
            tokExcitationPanelVm.GetTokExcitationRuleDatas().ForEach(l => gte.DrawLine(l.Pen, l.FirstPoint, l.SecondPoint));
            tokExcitationPanelVm.GetTokExcitationRuleInscription().ForEach(s => gte.DrawString(s.Text, s.Font, s.Brush, s.Position));
            tokExcitationPanelVm.GetTokExcitationRulePointerLine().ForEach(pl => gte.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
            tokExcitationPanelVm.GetTokExcitationRulePointer().ForEach(p => gte.DrawPolygon(p.Pen, p.Triangle));
            tokExcitationPanelVm.GetTokExcitationRuleFillPointer().ForEach(fp => gte.FillPolygon(fp.Brush, fp.Triangle));
            tokExcitationPanelVm.GetTokExcitationRuleTokAnchorMeaningZone().ForEach(sp => gte.FillRectangle(sp.Brush, sp.LeftTopX, sp.LeftTopY, sp.Width, sp.Height));
            tokExcitationPanelVm.DisposeDrawingAttributes();
            gte.Dispose();
            panel5.Invalidate();
        }

        private void UpdateDataBoxes(Parameters parameters)
        {
            var dataBoxVm = new DataBoxVm(parameters);
            this.Invoke((MethodInvoker)delegate
                {
                    textBox1.Text = dataBoxVm.GetDataBoxes()[0];
                    textBox2.Text = dataBoxVm.GetDataBoxes()[1];
                    textBox3.Text = dataBoxVm.GetDataBoxes()[2];
                    textBox4.Text = dataBoxVm.GetDataBoxes()[3];
                    textBox5.Text = dataBoxVm.GetDataBoxes()[4];
                });
        }

        private void UpdateLoadData(Parameters parameters)
        {
            var loadDataVm = new LoadDataVm(parameters);
            this.Invoke((MethodInvoker)delegate
                {
                    richTextBox1.BackColor = loadDataVm.GetLoadData()[0].BackColor;
                    richTextBox1.Text = loadDataVm.GetLoadData()[0].Text;
                    richTextBox4.BackColor = loadDataVm.GetLoadData()[3].BackColor;
                    richTextBox4.Text = loadDataVm.GetLoadData()[3].Text;
                    richTextBox2.BackColor = loadDataVm.GetLoadData()[1].BackColor;
                    richTextBox2.Text = loadDataVm.GetLoadData()[1].Text;
                    richTextBox3.BackColor = loadDataVm.GetLoadData()[2].BackColor;
                    richTextBox3.Text = loadDataVm.GetLoadData()[2].Text;
                });
        }


        private void UpdateCentralSignalsData(Parameters parameters)
        {
            var centralSignalsDataVm = new CentralSignalsDataVm(parameters);
            this.Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < 24; i++)
                {
                    masRichTextBox[i].BackColor = centralSignalsDataVm.SignalsData[i].BackColor;
                    masRichTextBox[i].Text = centralSignalsDataVm.SignalsData[i].Text;
                }
            });
            if (centralSignalsDataVm.SignalsData[11].BackColor == Color.Red && DefenceDiagramWorking == 0)
            {
                this.Invoke((MethodInvoker)delegate
            {
                tabControl1.SelectedIndex = 1;
            });
                DefenceDiagramWorking = 1;
            }
            if (centralSignalsDataVm.SignalsData[11].BackColor == Color.DarkGray && DefenceDiagramWorking == 1)
            {
                DefenceDiagramWorking = 0;
            }
        }

        private void UpdateAuziDInputOutputSignals(Parameters parameters)
        {
            var AuziDInOutSignalsVm = new AuziDInOutSignalsVm(parameters);
            this.Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < 32; i++)
                {
                    masInTextBox[i].BackColor = AuziDInOutSignalsVm.InputMeanings[i];
                    masInLabel[i].Text = AuziDInOutSignalsVm.InputNames[i];
                }
                for (int i = 0; i < 16; i++)
                {
                    masOutTextBox[i].BackColor = AuziDInOutSignalsVm.OutputMeanings[i];
                    masOutLabel[i].Text = AuziDInOutSignalsVm.OutputNames[i];
                }
            });
        }

        private void UpdateParametersData()
        {
           string[] variableParametersName = IoC.Resolve<MineConfig>().ParametersConfig.VariableParametersName;
           string[] variableParametersValue = IoC.Resolve<MineConfig>().ParametersConfig.VariableParametersValue;
            this.Invoke((MethodInvoker)delegate
            {
                dataGridViewParameters.RowCount = variableParametersName.Count();
                for (int i = 0; i < dataGridViewParameters.RowCount; i++)
                {
                    dataGridViewParameters[0, i].Value = i;
                    dataGridViewParameters[2, i].Value = variableParametersName[i];
                    dataGridViewParameters[3, i].Value = variableParametersValue[i];
                }
            });
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (btBac != null)
                e.Graphics.DrawImage(btBac, 0, 0);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (btBac_two != null)
                e.Graphics.DrawImage(btBac_two, 0, 0);
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            if (btBac_dop != null)
                e.Graphics.DrawImage(btBac_dop, 0, 0);
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            if (btBac_two_dop != null)
                e.Graphics.DrawImage(btBac_two_dop, 0, 0);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            if (btBac_speed != null)
                e.Graphics.DrawImage(btBac_speed, 0, 0);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            if (btBac_tok_anchor != null)
                e.Graphics.DrawImage(btBac_tok_anchor, 0, 0);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            if (btBac_tok_excitation != null)
                e.Graphics.DrawImage(btBac_tok_excitation, 0, 0);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            IoC.Resolve<FormSettingsParol>().ShowDialog();
        }

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
        private Thread updateGraphicThread;

    }
}
