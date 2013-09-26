using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ML.ConfigSettings.Services;
using ML.DataExchange;
using VisualizationSystem.Model;
using VisualizationSystem.Services;
using VisualizationSystem.ViewModel;

namespace VisualizationSystem.View
{
    public partial class MainView : UserControl
    {
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
        RichTextBox[] masRichTextBox = new RichTextBox[24];//массив текстбоксов для вывода сигналов цунтральной части экрана

        public MainView()
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            InitializeComponent();
            SetInitControlsFeatures();
            //SetGraphicInterval();
            _dataListener = IoC.Resolve<DataListener>();
            _dataListener.Init(ViewData,DrawLoad);
        }
        public void DrawLoad()
        {
            int LoadInterval = 9000 / (panel1.Width / 2 - panel1.Width / 6);
            AsyncProvider.StartTimer(LoadInterval, DrawLoadHandler);
        }
        public void DrawLoadHandler(System.Timers.Timer timer)
        {
            
        }
        private void MainView_Load(object sender, EventArgs e)
        {
            CreateRichTextBoxMassiv();
            SetGraphicInterval();
        }

        public void ViewData(Parameters parameters)
        {
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
            //UpdateGraphic(parameters);
            graphic_counter++;
            if (graphic_counter == 2)
            {
                graphic_counter = 0;
                Thread updateGraphicThread = new Thread(updateGraphicHandler);
                updateGraphicThread.Priority = ThreadPriority.Lowest;
                updateGraphicThread.Start(parameters);
            }
            UpdateCentralSignalsData(parameters);
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
                chartVA.ChartAreas[0].AxisY.Maximum = 100;
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

        private void updateGraphicHandler(object parameters)
        {
            var param = (Parameters) parameters;
            if (param.f_ostanov == 1)
                was_ostanov = 1;
            if (param.f_start == 1 || param.f_back == 1)
            {
                if (was_ostanov == 1)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        chartVA.Series[0].Points.Clear();
                        chartVA.Series[1].Points.Clear();
                        chartVA.Series[2].Points.Clear();
                    });
                    was_ostanov = 0;
                }
                this.Invoke((MethodInvoker)delegate
                {
                    chartVA.Series[0].Points.AddXY(-param.s, param.v / (IoC.Resolve<MineConfig>().MainViewConfig.MaxSpeed.Value / 100));
                    chartVA.Series[1].Points.AddXY(-param.s, param.tok_anchor / (IoC.Resolve<MineConfig>().MainViewConfig.MaxTokAnchor.Value / 100));
                    chartVA.Series[2].Points.AddXY(-param.s, param.tok_excitation / (IoC.Resolve<MineConfig>().MainViewConfig.MaxTokExcitation.Value / 100));
                });
            }
        }

        public void UpdateLeftPanel(Parameters parameters)
        {
            btBac = new Bitmap(panel1.Width, panel1.Height); // панель клети
            Graphics g = Graphics.FromImage(btBac);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var leftPanelVm = new LeftPanelVm(panel1.Width, panel1.Height, parameters);
            leftPanelVm.GetMainRuleDatas().ForEach(l => g.DrawLine(l.Pen, l.FirstPoint, l.SecondPoint));
            leftPanelVm.GetMainRuleInscription().ForEach(s => g.DrawString(s.Text, s.Font, s.Brush, s.Position));
            leftPanelVm.GetMainRuleZones().ForEach(z => g.FillRectangle(z.Brush, z.LeftTopX, z.LeftTopY, z.Width, z.Height));
            leftPanelVm.GetMainRulePointerLine().ForEach(pl => g.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
            leftPanelVm.GetMainRulePointer().ForEach(p => g.DrawPolygon(p.Pen, p.Triangle));
            leftPanelVm.GetMainRuleFillPointer().ForEach(fp => g.FillPolygon(fp.Brush, fp.Triangle));
            leftPanelVm.GetMainRuleCage().ForEach(c => g.FillRectangle(c.Brush, c.LeftTopX, c.LeftTopY, c.Width, c.Height));
            leftPanelVm.GetMainRuleDirectionPointer().ForEach(dp => g.DrawPolygon(dp.Pen, dp.Triangle));
            leftPanelVm.GetMainRuleDirectionFillPointer().ForEach(dfp => g.FillPolygon(dfp.Brush, dfp.Triangle));
            leftPanelVm.DisposeDrawingAttributes();
            g.Dispose();
            panel1.Invalidate();
        }

        public void UpdateRightPanel(Parameters parameters)
        {
            btBac_two = new Bitmap(panel2.Width, panel2.Height); // панель противовеса
            Graphics gr = Graphics.FromImage(btBac_two);
            gr.SmoothingMode = SmoothingMode.AntiAlias;

            var rightPanelVm = new RightPanelVm(panel2.Width, panel2.Height, parameters);
            rightPanelVm.GetMainRuleDatas().ForEach(l => gr.DrawLine(l.Pen, l.FirstPoint, l.SecondPoint));
            rightPanelVm.GetMainRuleInscription().ForEach(s => gr.DrawString(s.Text, s.Font, s.Brush, s.Position));
            rightPanelVm.GetMainRuleZones().ForEach(z => gr.FillRectangle(z.Brush, z.LeftTopX, z.LeftTopY, z.Width, z.Height));
            rightPanelVm.GetMainRulePointerLine().ForEach(pl => gr.DrawLine(pl.Pen, pl.FirstPoint, pl.SecondPoint));
            rightPanelVm.GetMainRulePointer().ForEach(p => gr.DrawPolygon(p.Pen, p.Triangle));
            rightPanelVm.GetMainRuleFillPointer().ForEach(fp => gr.FillPolygon(fp.Brush, fp.Triangle));
            rightPanelVm.GetMainRuleCage().ForEach(c => gr.FillRectangle(c.Brush, c.LeftTopX, c.LeftTopY, c.Width, c.Height));
            rightPanelVm.GetMainRuleDirectionPointer().ForEach(dp => gr.DrawPolygon(dp.Pen, dp.Triangle));
            rightPanelVm.GetMainRuleDirectionFillPointer().ForEach(dfp => gr.FillPolygon(dfp.Brush, dfp.Triangle));
            rightPanelVm.DisposeDrawingAttributes();
            gr.Dispose();
            panel2.Invalidate();
        }

        public void UpdateLeftDopPanel(Parameters parameters)
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

        public void UpdateRightDopPanel(Parameters parameters)
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

        public void UpdateSpeedPanel(Parameters parameters)
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

        public void UpdateTokAnchorPanel(Parameters parameters)
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

        public void UpdateTokExitationPanel(Parameters parameters)
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

        public void UpdateDataBoxes(Parameters parameters)
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

        public void UpdateLoadData(Parameters parameters)
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

        public void UpdateGraphic(Parameters parameters)
        {
           /* var graphicVaVm = new GraphicVaVm(parameters);
            if (parameters.f_start == 1 || parameters.f_back == 1)
            {
                if (graphicVaVm.was_ostanov == 1)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        chartVA.Series[0].Points.Clear();
                        chartVA.Series[1].Points.Clear();
                        chartVA.Series[2].Points.Clear();
                    });
                    graphicVaVm.was_ostanov = 0;
                }
                this.Invoke((MethodInvoker)delegate
                {
                    chartVA.Series[0].Points.AddXY(graphicVaVm.Graphic[0].X, graphicVaVm.Graphic[0].Y);
                    chartVA.Series[1].Points.AddXY(graphicVaVm.Graphic[1].X, graphicVaVm.Graphic[1].Y);
                    chartVA.Series[2].Points.AddXY(graphicVaVm.Graphic[2].X, graphicVaVm.Graphic[2].Y);
                });
            } */
            if (parameters.f_ostanov == 1)
                was_ostanov = 1;
            if (parameters.f_start == 1 || parameters.f_back == 1)
            {
                if (was_ostanov == 1)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                    chartVA.Series[0].Points.Clear();
                    chartVA.Series[1].Points.Clear();
                    chartVA.Series[2].Points.Clear();
                    });
                    was_ostanov = 0;
                }
                this.Invoke((MethodInvoker)delegate
                    {
                chartVA.Series[0].Points.AddXY(parameters.s, parameters.v / (IoC.Resolve<MineConfig>().MainViewConfig.MaxSpeed.Value / 100));
                chartVA.Series[1].Points.AddXY(parameters.s, parameters.tok_anchor / (IoC.Resolve<MineConfig>().MainViewConfig.MaxTokAnchor.Value / 100));
                chartVA.Series[2].Points.AddXY(parameters.s, parameters.tok_excitation / (IoC.Resolve<MineConfig>().MainViewConfig.MaxTokExcitation.Value / 100));
                    });
            }
        }

        public void UpdateCentralSignalsData(Parameters parameters)
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
            IoC.Resolve<FormSettings>().ShowDialog();
        }

 
    }
}
