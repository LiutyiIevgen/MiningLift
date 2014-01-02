using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ML.ConfigSettings.Services;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using VisualizationSystem.Model;
using VisualizationSystem.ViewModel;

namespace VisualizationSystem.View.UserControls.Setting
{
    public partial class DefenceDiagramSettings : UserControl
    {
        public DefenceDiagramSettings()
        {
            InitializeComponent();
        }

        private void DefenceDiagramSettings_Load(object sender, EventArgs e)
        {
            //SetGraphicInterval();
            //UpdateData();
            MakeGraphic();
            UpdateDiagramData();
        }

        private void MakeGraphic()
        {
            var defenceDiagramSettingsVm = new DefenceDiagramSettingsVm();
            if (defenceDiagramSettingsVm.HzCrossHkDown == 1 || defenceDiagramSettingsVm.HzCrossHkUp == 1)
            {
                MessageBox.Show("Защитная диаграмма пересекается с критической!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                var plotDefenceDiagram = new OxyPlot.WindowsForms.Plot {Model = new PlotModel(), Dock = DockStyle.Fill};
                this.tabControl1.TabPages[0].Controls.Add(plotDefenceDiagram);
                //Legend
                plotDefenceDiagram.Model.PlotType = PlotType.XY;
                //plotDefenceDiagram.Model.LegendTitle = "Legend";
                plotDefenceDiagram.Model.LegendOrientation = LegendOrientation.Horizontal;
                plotDefenceDiagram.Model.LegendPlacement = LegendPlacement.Outside;
                plotDefenceDiagram.Model.LegendPosition = LegendPosition.TopRight;
                plotDefenceDiagram.Model.LegendBackground = OxyColor.FromAColor(200, OxyColors.White);
                plotDefenceDiagram.Model.LegendBorder = OxyColors.Gray;
                //Axis
                var xAxis = new LinearAxis(AxisPosition.Bottom, 0)
                {
                    MajorGridlineStyle = LineStyle.Solid,
                    MinorGridlineStyle = LineStyle.Dot,
                    Title = "Путь (м)",
                    Minimum = -IoC.Resolve<MineConfig>().MainViewConfig.Border.Value,
                    Maximum = -IoC.Resolve<MineConfig>().MainViewConfig.BorderZero.Value
                };
                plotDefenceDiagram.Model.Axes.Add(xAxis);
                var yAxis = new LinearAxis(AxisPosition.Left, 0)
                {
                    MajorGridlineStyle = LineStyle.Solid,
                    MinorGridlineStyle = LineStyle.Dot,
                    Title = "Скорость (м/с)",
                    Minimum = 0,
                    Maximum =
                        1.2*
                        Convert.ToDouble(IoC.Resolve<MineConfig>().ParametersConfig.VariableParametersValue[0],
                            CultureInfo.GetCultureInfo("en-US"))
                };
                plotDefenceDiagram.Model.Axes.Add(yAxis);
                // Create Line series
                var s1 = new LineSeries {Title = "Груз", StrokeThickness = 1, Color = OxyColors.Blue};
                var s2 = new LineSeries {Title = "Люди", StrokeThickness = 1, Color = OxyColors.Green};
                var s3 = new LineSeries {Title = "Оборудование", StrokeThickness = 1, Color = OxyColors.Red};
                var s4 = new LineSeries {Title = "Ревизия", StrokeThickness = 1, Color = OxyColors.Orange};
                for (int i = 0; i < defenceDiagramSettingsVm.DiagramVeight.Count(); i++)
                {
                    s1.Points.Add(new DataPoint(-defenceDiagramSettingsVm.DiagramVeight[i].X,
                        defenceDiagramSettingsVm.DiagramVeight[i].Y));
                    s2.Points.Add(new DataPoint(-defenceDiagramSettingsVm.DiagramPeople[i].X,
                        defenceDiagramSettingsVm.DiagramPeople[i].Y));
                    s3.Points.Add(new DataPoint(-defenceDiagramSettingsVm.DiagramEquipment[i].X,
                        defenceDiagramSettingsVm.DiagramEquipment[i].Y));
                }
                for (int i = 0; i < defenceDiagramSettingsVm.DiagramRevision.Count(); i++)
                {
                    s4.Points.Add(new DataPoint(-defenceDiagramSettingsVm.DiagramRevision[i].X,
                        defenceDiagramSettingsVm.DiagramRevision[i].Y));
                }
                // add Series and Axis to plot model
                plotDefenceDiagram.Model.Series.Add(s1);
                plotDefenceDiagram.Model.Series.Add(s2);
                plotDefenceDiagram.Model.Series.Add(s3);
                plotDefenceDiagram.Model.Series.Add(s4);
            }
        }

        private void UpdateDiagramData()
        {
            var defenceDiagramSettingsVm = new DefenceDiagramSettingsVm();
            if (defenceDiagramSettingsVm.HzCrossHkDown == 0 && defenceDiagramSettingsVm.HzCrossHkUp == 0)
            {
                dataGridViewDefenceDiagramDown.RowCount = defenceDiagramSettingsVm.vVeight.Count();
                dataGridViewDefenceDiagramUp.RowCount = defenceDiagramSettingsVm.vVeight.Count();
                for (int i = 0; i < defenceDiagramSettingsVm.vVeight.Count(); i++)
                {
                    dataGridViewDefenceDiagramDown[0, i].Value = i;
                    dataGridViewDefenceDiagramDown[1, i].Value = Math.Round(defenceDiagramSettingsVm.vVeight[i], 3);
                    dataGridViewDefenceDiagramDown[2, i].Value = -Math.Round(IoC.Resolve<MineConfig>().MainViewConfig.Border.Value - defenceDiagramSettingsVm.hzVeightDown[i], 3);
                    dataGridViewDefenceDiagramDown[3, i].Value = Math.Round(defenceDiagramSettingsVm.vPeople[i], 3);
                    dataGridViewDefenceDiagramDown[4, i].Value = -Math.Round(IoC.Resolve<MineConfig>().MainViewConfig.Border.Value - defenceDiagramSettingsVm.hzPeopleDown[i], 3);
                    dataGridViewDefenceDiagramDown[5, i].Value = Math.Round(defenceDiagramSettingsVm.vEquipment[i], 3);
                    dataGridViewDefenceDiagramDown[6, i].Value = -Math.Round(IoC.Resolve<MineConfig>().MainViewConfig.Border.Value - defenceDiagramSettingsVm.hzEquipmentDown[i], 3);
                    dataGridViewDefenceDiagramDown[7, i].Value = Math.Round(defenceDiagramSettingsVm.vRevision[i], 3);
                    dataGridViewDefenceDiagramDown[8, i].Value = -Math.Round(IoC.Resolve<MineConfig>().MainViewConfig.Border.Value - defenceDiagramSettingsVm.hzRevision[i], 3);
                    dataGridViewDefenceDiagramUp[0, i].Value = i;
                    dataGridViewDefenceDiagramUp[1, i].Value = Math.Round(defenceDiagramSettingsVm.vVeight[i], 3);
                    dataGridViewDefenceDiagramUp[2, i].Value = -Math.Round(defenceDiagramSettingsVm.hzVeightUp[i], 3);
                    dataGridViewDefenceDiagramUp[3, i].Value = Math.Round(defenceDiagramSettingsVm.vPeople[i], 3);
                    dataGridViewDefenceDiagramUp[4, i].Value = -Math.Round(defenceDiagramSettingsVm.hzPeopleUp[i], 3);
                    dataGridViewDefenceDiagramUp[5, i].Value = Math.Round(defenceDiagramSettingsVm.vEquipment[i], 3);
                    dataGridViewDefenceDiagramUp[6, i].Value = -Math.Round(defenceDiagramSettingsVm.hzEquipmentUp[i], 3);
                    dataGridViewDefenceDiagramUp[7, i].Value = Math.Round(defenceDiagramSettingsVm.vRevision[i], 3);
                    dataGridViewDefenceDiagramUp[8, i].Value = -Math.Round(defenceDiagramSettingsVm.hzRevision[i], 3);
                }
            }
        }

       /* private void SetGraphicInterval()
        {
            chartDefenceDiagram.ChartAreas[0].AxisX.Minimum = -IoC.Resolve<MineConfig>().MainViewConfig.Border.Value;
            chartDefenceDiagram.ChartAreas[0].AxisX.Maximum = IoC.Resolve<MineConfig>().MainViewConfig.BorderZero.Value;
            chartDefenceDiagram.ChartAreas[0].AxisX.Interval = IoC.Resolve<MineConfig>().MainViewConfig.Distance.Value / 8;
            chartDefenceDiagram.ChartAreas[0].AxisY.Minimum = 0;
            chartDefenceDiagram.ChartAreas[0].AxisY.Maximum = 15;
            chartDefenceDiagram.ChartAreas[0].AxisY.Interval = 3;
        } */

       /* private void UpdateData()
        {
            var defenceDiagramSettingsVm = new DefenceDiagramSettingsVm();
            chartDefenceDiagram.Series[0].Points.Clear();
            chartDefenceDiagram.Series[1].Points.Clear();
            chartDefenceDiagram.Series[2].Points.Clear();
            chartDefenceDiagram.Series[3].Points.Clear();
            for (int i = 0; i < defenceDiagramSettingsVm.DiagramVeight.Count(); i++)
            {
                chartDefenceDiagram.Series[0].Points.AddXY(-defenceDiagramSettingsVm.DiagramVeight[i].X, defenceDiagramSettingsVm.DiagramVeight[i].Y);
                chartDefenceDiagram.Series[1].Points.AddXY(-defenceDiagramSettingsVm.DiagramPeople[i].X, defenceDiagramSettingsVm.DiagramPeople[i].Y);
                chartDefenceDiagram.Series[2].Points.AddXY(-defenceDiagramSettingsVm.DiagramEquipment[i].X, defenceDiagramSettingsVm.DiagramEquipment[i].Y);
            }
            for (int i = 0; i < defenceDiagramSettingsVm.DiagramRevision.Count(); i++)
            {
                chartDefenceDiagram.Series[3].Points.AddXY(-defenceDiagramSettingsVm.DiagramRevision[i].X, defenceDiagramSettingsVm.DiagramRevision[i].Y);
            }
        } */
    }
}
