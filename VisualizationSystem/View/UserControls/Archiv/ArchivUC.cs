using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
//using System.Windows.Forms.DataVisualization.Charting;
using ML.ConfigSettings.Services;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using VisualizationSystem.Model;
using VisualizationSystem.Services;
using DataPoint = OxyPlot.DataPoint;

namespace VisualizationSystem.View.UserControls.Archiv
{
    public partial class ArchivUC : UserControl
    {
        public ArchivUC()
        {
            InitializeComponent();
            _mineConfig = IoC.Resolve<MineConfig>();
            plotAnalogSignals = new OxyPlot.WindowsForms.Plot { Model = new PlotModel(), Dock = DockStyle.Fill };
            panel1.Controls.Clear();
            panel1.Controls.Add(plotAnalogSignals);
            plotAnalogSignals.Model.Series.Add(s1);
            plotAnalogSignals.Model.Series.Add(s2);
            plotAnalogSignals.Model.Series.Add(s3);
            plotAnalogSignals.Model.Series.Add(s4);
            plotAnalogSignals.Model.Series.Add(s5);
            plotAnalogSignals.Model.Series.Add(s6);
            plotAnalogSignals.Model.Series.Add(s7);
        }

        private void ArchivUC_Load(object sender, EventArgs e)
        {
            SetAnalogSignalsNamesList();
            comboBoxOC.SelectedIndex = 0;
        }

        private void SetAnalogSignalsNamesList()
        {
            var names = _dataBaseService.GetAnalogSignalsNames();
            foreach (var name in names)
            {
                listViewAnalogSignals.Items.Add(name);
            }
            listViewAnalogSignals.Items[0].ForeColor = Color.Blue;
            listViewAnalogSignals.Items[1].ForeColor = Color.Magenta;
            listViewAnalogSignals.Items[2].ForeColor = Color.Green;
            listViewAnalogSignals.Items[3].ForeColor = Color.IndianRed;
            listViewAnalogSignals.Items[4].ForeColor = Color.DarkOrange;
            listViewAnalogSignals.Items[5].ForeColor = Color.Yellow;
            listViewAnalogSignals.Items[6].ForeColor = Color.Red;
        }

        private void MakeAnalogSignalsGraphic(List<List<List<string>>> analogSignals, List<DateTime> dateTimes)
        {
            int oc = comboBoxOC.SelectedIndex;
            var lineSerie1 = plotAnalogSignals.Model.Series[0] as LineSeries;
            var lineSerie2 = plotAnalogSignals.Model.Series[1] as LineSeries;
            var lineSerie3 = plotAnalogSignals.Model.Series[2] as LineSeries;
            var lineSerie4 = plotAnalogSignals.Model.Series[3] as LineSeries;
            var lineSerie5 = plotAnalogSignals.Model.Series[4] as LineSeries;
            var lineSerie6 = plotAnalogSignals.Model.Series[5] as LineSeries;
            var lineSerie7 = plotAnalogSignals.Model.Series[6] as LineSeries;
            //Legend
            plotAnalogSignals.Model.PlotType = PlotType.XY;
            //Axis
            plotAnalogSignals.Model.Axes.Clear();
            var xAxis = new DateTimeAxis(AxisPosition.Bottom, dateTimes[0], dateTimes[dateTimes.Count - 1], null, null, DateTimeIntervalType.Auto)
            {
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                //Title = "Дата",
                StringFormat = "dd-MM-yyyy\nHH:mm:ss",
                IsZoomEnabled = true,
                MajorStep = 1.0 / 24 / 60 / 2,
                MinorStep = 1.0 / 24 / 60 / 12,
            };
            plotAnalogSignals.Model.Axes.Add(xAxis);
            var yAxis = new LinearAxis(AxisPosition.Left, 0)
            {
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Title = "%"
            };
            plotAnalogSignals.Model.Axes.Add(yAxis);
            // Create Line series
            lineSerie1.Points.Clear();
            lineSerie2.Points.Clear();
            lineSerie3.Points.Clear();
            lineSerie4.Points.Clear();
            lineSerie5.Points.Clear();
            lineSerie6.Points.Clear();
            lineSerie7.Points.Clear();
            for (int i = 0; i < dateTimes.Count; i++)
            {
                lineSerie1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dateTimes[i]), Convert.ToDouble(analogSignals[oc][0][i])));
                lineSerie2.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dateTimes[i]), Convert.ToDouble(analogSignals[oc][1][i])));
                lineSerie3.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dateTimes[i]), Convert.ToDouble(analogSignals[oc][2][i])));
                lineSerie4.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dateTimes[i]), Convert.ToDouble(analogSignals[oc][3][i])));
                lineSerie5.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dateTimes[i]), Convert.ToDouble(analogSignals[oc][4][i])));
                lineSerie6.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dateTimes[i]), Convert.ToDouble(analogSignals[oc][5][i])));
                lineSerie7.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dateTimes[i]), Convert.ToDouble(analogSignals[oc][6][i])));
            }
            int j = 0;
            foreach (ListViewItem item in listViewAnalogSignals.Items)
            {
                plotAnalogSignals.Model.Series[j].IsVisible = listViewAnalogSignals.CheckedItems.Contains(item);
                j++;
            }
            plotAnalogSignals.RefreshPlot(true);
        } 

        private void buttonFind_Click(object sender, EventArgs e)
        {
            var blocksIds = _dataBaseService.GetBlocksIds(dateTimePicker1.Value, dateTimePicker2.Value);
            _blocksDates = _dataBaseService.GetBlocksDateTimes(dateTimePicker1.Value, dateTimePicker2.Value);
            //analog signals
            var names = _dataBaseService.GetAnalogSignalsNames();
            _analogSignals = new List<List<List<string>>>();
            for (int j = 0; j < 3; j++)
            {
                _analogSignals.Add(new List<List<string>>());
            }
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < names.Count; i++)
                {
                    _analogSignals[j].Add(new List<string>());
                }
            }
            for (int j = 0; j < blocksIds.Count; j++)
            {
                var listSignalsList = _dataBaseService.GetAnalogSignalsById(blocksIds[j]);
                for (int i = 0; i < 3; i++)
                {
                    for (int k = 0; k < names.Count; k++)
                    {
                        _analogSignals[i][k].Add(listSignalsList[i][k].Value);
                    }
                }
            }
            if (_blocksDates.Count > 0)
                MakeAnalogSignalsGraphic(_analogSignals, _blocksDates);
            //
        }

        private void listViewAnalogSignals_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            int j = 0;
            foreach (ListViewItem item in listViewAnalogSignals.Items)
            {
                plotAnalogSignals.Model.Series[j].IsVisible = listViewAnalogSignals.CheckedItems.Contains(item);
                j++;
            }
            plotAnalogSignals.RefreshPlot(true);
        }

        private void comboBoxOC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_blocksDates != null && _blocksDates.Count > 0)
                MakeAnalogSignalsGraphic(_analogSignals, _blocksDates);
        }

        private MineConfig _mineConfig;
        readonly DataBaseService _dataBaseService = IoC.Resolve<DataBaseService>();
        private OxyPlot.WindowsForms.Plot plotAnalogSignals;
        private List<List<List<string>>> _analogSignals;
        private List<DateTime> _blocksDates;
        private LineSeries s1 = new LineSeries { StrokeThickness = 1, Color = OxyColors.Blue, MarkerType = MarkerType.Circle, MarkerStroke = OxyColors.Blue, MarkerFill = OxyColors.Blue, MarkerSize = 2};
        private LineSeries s2 = new LineSeries { StrokeThickness = 1, Color = OxyColors.Magenta };
        private LineSeries s3 = new LineSeries { StrokeThickness = 1, Color = OxyColors.Green };
        private LineSeries s4 = new LineSeries { StrokeThickness = 1, Color = OxyColors.IndianRed};
        private LineSeries s5 = new LineSeries { StrokeThickness = 1, Color = OxyColors.DarkOrange };
        private LineSeries s6 = new LineSeries { StrokeThickness = 1, Color = OxyColors.Yellow };
        private LineSeries s7 = new LineSeries { StrokeThickness = 1, Color = OxyColors.Red };

    }
}
