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
            SetInitControlsFeatures();
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
            ViewData(new Parameters(param));
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

        public void SetInitControlsFeatures()
        {
            label3.ForeColor = Color.FromArgb(150, 0, 255, 0);
            label7.ForeColor = Color.FromArgb(150, 255, 165, 0);
            label10.ForeColor = Color.FromArgb(125, 255, 255, 0);
            textBox3.ForeColor = Color.FromArgb(150, 0, 255, 0);
            textBox4.ForeColor = Color.FromArgb(150, 255, 165, 0);
            textBox5.ForeColor = Color.FromArgb(125, 255, 255, 0);
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox2.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox3.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox4.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox5.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox6.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox7.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox8.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox9.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox10.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox11.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox12.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox13.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox14.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox15.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox16.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox17.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox18.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox19.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox20.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox21.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox22.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox23.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox24.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox25.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox26.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox27.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox28.SelectionAlignment = HorizontalAlignment.Center;
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
            this.Invoke((MethodInvoker)delegate
            {
                masRichTextBox[0] = richTextBox5;
                masRichTextBox[1] = richTextBox6;
                masRichTextBox[2] = richTextBox7;
                masRichTextBox[3] = richTextBox8;
                masRichTextBox[4] = richTextBox9;
                masRichTextBox[5] = richTextBox10;
                masRichTextBox[6] = richTextBox11;
                masRichTextBox[7] = richTextBox12;
                masRichTextBox[8] = richTextBox13;
                masRichTextBox[9] = richTextBox14;
                masRichTextBox[10] = richTextBox15;
                masRichTextBox[11] = richTextBox16;
                masRichTextBox[12] = richTextBox17;
                masRichTextBox[13] = richTextBox18;
                masRichTextBox[14] = richTextBox19;
                masRichTextBox[15] = richTextBox20;
                masRichTextBox[16] = richTextBox21;
                masRichTextBox[17] = richTextBox22;
                masRichTextBox[18] = richTextBox23;
                masRichTextBox[19] = richTextBox24;
                masRichTextBox[20] = richTextBox25;
                masRichTextBox[21] = richTextBox26;
                masRichTextBox[22] = richTextBox27;
                masRichTextBox[23] = richTextBox28;
            });
        }

        private void CreateAuziDIOSignalsMassiv()
        {
            this.Invoke((MethodInvoker)delegate
            {
            masInTextBox[0] = textBox6;
            masInTextBox[1] = textBox7;
            masInTextBox[2] = textBox8;
            masInTextBox[3] = textBox9;
            masInTextBox[4] = textBox10;
            masInTextBox[5] = textBox11;
            masInTextBox[6] = textBox12;
            masInTextBox[7] = textBox13;
            masInTextBox[8] = textBox14;
            masInTextBox[9] = textBox15;
            masInTextBox[10] = textBox16;
            masInTextBox[11] = textBox17;
            masInTextBox[12] = textBox18;
            masInTextBox[13] = textBox19;
            masInTextBox[14] = textBox20;
            masInTextBox[15] = textBox21;
            masInTextBox[16] = textBox22;
            masInTextBox[17] = textBox23;
            masInTextBox[18] = textBox24;
            masInTextBox[19] = textBox25;
            masInTextBox[20] = textBox26;
            masInTextBox[21] = textBox27;
            masInTextBox[22] = textBox28;
            masInTextBox[23] = textBox29;
            masInTextBox[24] = textBox30;
            masInTextBox[25] = textBox31;
            masInTextBox[26] = textBox32;
            masInTextBox[27] = textBox33;
            masInTextBox[28] = textBox34;
            masInTextBox[29] = textBox35;
            masInTextBox[30] = textBox36;
            masInTextBox[31] = textBox37;
            masOutTextBox[0] = textBox38;
            masOutTextBox[1] = textBox39;
            masOutTextBox[2] = textBox40;
            masOutTextBox[3] = textBox41;
            masOutTextBox[4] = textBox42;
            masOutTextBox[5] = textBox43;
            masOutTextBox[6] = textBox44;
            masOutTextBox[7] = textBox45;
            masOutTextBox[8] = textBox46;
            masOutTextBox[9] = textBox47;
            masOutTextBox[10] = textBox48;
            masOutTextBox[11] = textBox49;
            masOutTextBox[12] = textBox50;
            masOutTextBox[13] = textBox51;
            masOutTextBox[14] = textBox52;
            masOutTextBox[15] = textBox53;

            masInLabel[0] = label4;
            masInLabel[1] = label5;
            masInLabel[2] = label11;
            masInLabel[3] = label12;
            masInLabel[4] = label13;
            masInLabel[5] = label14;
            masInLabel[6] = label15;
            masInLabel[7] = label16;
            masInLabel[8] = label17;
            masInLabel[9] = label18;
            masInLabel[10] = label19;
            masInLabel[11] = label20;
            masInLabel[12] = label21;
            masInLabel[13] = label22;
            masInLabel[14] = label23;
            masInLabel[15] = label24;
            masInLabel[16] = label25;
            masInLabel[17] = label26;
            masInLabel[18] = label27;
            masInLabel[19] = label28;
            masInLabel[20] = label29;
            masInLabel[21] = label30;
            masInLabel[22] = label31;
            masInLabel[23] = label32;
            masInLabel[24] = label33;
            masInLabel[25] = label34;
            masInLabel[26] = label35;
            masInLabel[27] = label36;
            masInLabel[28] = label37;
            masInLabel[29] = label38;
            masInLabel[30] = label39;
            masInLabel[31] = label40;
            masOutLabel[0] = label41;
            masOutLabel[1] = label42;
            masOutLabel[2] = label43;
            masOutLabel[3] = label44;
            masOutLabel[4] = label45;
            masOutLabel[5] = label46;
            masOutLabel[6] = label47;
            masOutLabel[7] = label48;
            masOutLabel[8] = label49;
            masOutLabel[9] = label50;
            masOutLabel[10] = label51;
            masOutLabel[11] = label52;
            masOutLabel[12] = label53;
            masOutLabel[13] = label54;
            masOutLabel[14] = label55;
            masOutLabel[15] = label56;
            });
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
        private RichTextBox[] masRichTextBox = new RichTextBox[24];//массив текстбоксов для вывода сигналов цунтральной части экрана
        private TextBox[] masInTextBox = new TextBox[32];//массив текстбоксов для вывода входных сигналов АУЗИ-Д
        private Label[] masInLabel = new Label[32];//массив лейблов для вывода входных сигналов АУЗИ-Д
        private TextBox[] masOutTextBox = new TextBox[16];//массив текстбоксов для вывода выходных сигналов АУЗИ-Д
        private Label[] masOutLabel = new Label[16];//массив лейблов для вывода выходных сигналов АУЗИ-Д
        private Thread updateGraphicThread;

    }
}
