using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ML.ConfigSettings.Services;
using ML.DataExchange.Model;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using VisualizationSystem.Model;

namespace VisualizationSystem.View.UserControls.GeneralView
{
    public partial class CycleUC : UserControl
    {
        public CycleUC()
        {
            InitializeComponent();
            plotCycle = new OxyPlot.WindowsForms.Plot { Model = new PlotModel(), Dock = DockStyle.Fill };
            this.panel1.Controls.Add(plotCycle);
            plotCycle.Model.PlotType = PlotType.XY;
            for (int i = 0; i < checkedListBoxGraphic.Items.Count; i++)
                checkedListBoxGraphic.SetItemChecked(i, true);
            _mineConfig = IoC.Resolve<MineConfig>();
        }

        public void SetGraphicInterval()
        {
            //SetGraphicInterval();
            this.Invoke((MethodInvoker)delegate
            {
                //Axis
                var xAxis = new LinearAxis(AxisPosition.Bottom, 0)
                {
                    MajorGridlineStyle = LineStyle.Solid,
                    MinorGridlineStyle = LineStyle.Dot,
                    Title = "м",
                    Maximum = -_mineConfig.MainViewConfig.BorderZero.Value,
                    Minimum = -_mineConfig.MainViewConfig.Border.Value
                };
                plotCycle.Model.Axes.Add(xAxis);
                var yAxis = new LinearAxis(AxisPosition.Left, 0)
                {
                    MajorGridlineStyle = LineStyle.Solid,
                    MinorGridlineStyle = LineStyle.Dot,
                    Title = "%",
                    Minimum = -100,
                    Maximum = 120
                };
                plotCycle.Model.Axes.Add(yAxis);
                /*chartVA.ChartAreas[0].AxisX.Minimum = -_mineConfig.MainViewConfig.Border.Value;
                chartVA.ChartAreas[0].AxisX.Maximum = -_mineConfig.MainViewConfig.BorderZero.Value;
                chartVA.ChartAreas[0].AxisX.Interval = _mineConfig.MainViewConfig.Distance.Value / 10;
                chartVA.ChartAreas[0].AxisY.Minimum = -100;
                chartVA.ChartAreas[0].AxisY.Maximum = 120;
                chartVA.ChartAreas[0].AxisY.Interval = 20; */
            });
        }

       /* public void ChangeGraphicInterval()
        {
            this.Invoke((MethodInvoker)delegate
            {
                //Axis
                plotCycle.Model.DefaultXAxis.Maximum = -_mineConfig.MainViewConfig.BorderZero.Value;
                plotCycle.Model.DefaultXAxis.Minimum = -_mineConfig.MainViewConfig.Border.Value;
            });
        } */

        public void Refresh(Parameters parameters)
        {
            //plotCycle.Model.Axes.Clear();
            //SetGraphicInterval();
            var param = parameters as Parameters;
            if (param.f_start == 1 || param.f_back == 1)
            {
                //var defenceDiagramVm = new DefenceDiagramVm(param);
                if (param.f_ostanov == 1)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        plotCycle.Model.Series.Clear();
                       /* chartVA.Series[0].Points.Clear();
                        chartVA.Series[1].Points.Clear();
                        chartVA.Series[2].Points.Clear();
                        chartVA.Series[3].Points.Clear(); */
                    });
                }
                this.Invoke((MethodInvoker)delegate
                {
                    // Add Line series
                    //var s1 = new LineSeries { StrokeThickness = 1, Color = OxyColors.Blue };
                        s1.Points.Add(new DataPoint(-param.s, param.v / (_mineConfig.MainViewConfig.MaxSpeed.Value / 100)));
                        s2.Points.Add(new DataPoint(-param.s, param.tok_anchor / (_mineConfig.MainViewConfig.MaxTokAnchor.Value / 100)));
                        s3.Points.Add(new DataPoint(-param.s, param.tok_excitation / (_mineConfig.MainViewConfig.MaxTokExcitation.Value / 100)));
                        s4.Points.Add(new DataPoint(-param.s, param.defence_diagram / (_mineConfig.MainViewConfig.MaxSpeed.Value * 1.2 / 100)));
                    // add Series and Axis to plot model
                    plotCycle.Model.Series.Clear();
                    plotCycle.Model.Series.Add(s1);
                    plotCycle.Model.Series.Add(s2);
                    plotCycle.Model.Series.Add(s3);
                    plotCycle.Model.Series.Add(s4);
                    plotCycle.RefreshPlot(true);

                    int j = 0;
                    foreach (object item in checkedListBoxGraphic.Items)
                    {
                        plotCycle.Model.Series[j].IsVisible = checkedListBoxGraphic.CheckedItems.Contains(item);
                        //chartVA.Series[j].Enabled = checkedListBoxGraphic.CheckedItems.Contains(item);
                        j++;
                    }
                });
            }
        }

        private MineConfig _mineConfig;
        private OxyPlot.WindowsForms.Plot plotCycle;
        private LineSeries s1 = new LineSeries { StrokeThickness = 1, Color = OxyColors.LimeGreen };
        private LineSeries s2 = new LineSeries { StrokeThickness = 1, Color = OxyColors.DarkOrange };
        private LineSeries s3 = new LineSeries { StrokeThickness = 1, Color = OxyColors.Yellow };
        private LineSeries s4 = new LineSeries { StrokeThickness = 1, Color = OxyColors.Red };
    }
}
