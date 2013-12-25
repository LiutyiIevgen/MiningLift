using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ML.ConfigSettings.Services;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using VisualizationSystem.Model;

namespace VisualizationSystem.View
{
    public partial class FormCodtDomainParamType : Form
    {
        private int _index;
        private string[] _coordinate = null;
        private string[] _speed = null;
        private OxyPlot.WindowsForms.Plot plotDefenceDiagram;
        public FormCodtDomainParamType()
        {
            InitializeComponent();
        }

        public FormCodtDomainParamType(int index)
        {
            InitializeComponent();
            _index = index;
            LoadData(_index);
            plotDefenceDiagram = new OxyPlot.WindowsForms.Plot { Model = new PlotModel(), Dock = DockStyle.Fill };
            this.splitContainer2.Panel2.Controls.Add(plotDefenceDiagram);
            MakeGraphic();
        }

        private void FormCodtDomainParamType_Load(object sender, EventArgs e)
        {

        }

        private void LoadData(int index)
        {
            if (index == 0x2035)
            {
                _coordinate = IoC.Resolve<MineConfig>().ParametersConfig.CoordinateRevision;
                _speed = IoC.Resolve<MineConfig>().ParametersConfig.SpeedRevision;
            }
            else if (index == 0x2036)
            {
                _coordinate = IoC.Resolve<MineConfig>().ParametersConfig.CoordinateVeight;
                _speed = IoC.Resolve<MineConfig>().ParametersConfig.SpeedVeight;
            }
            else if (index == 0x2037)
            {
                _coordinate = IoC.Resolve<MineConfig>().ParametersConfig.CoordinateEquipment;
                _speed = IoC.Resolve<MineConfig>().ParametersConfig.SpeedEquipment;
            }
            else if (index == 0x2038)
            {
                _coordinate = IoC.Resolve<MineConfig>().ParametersConfig.CoordinatePeople;
                _speed = IoC.Resolve<MineConfig>().ParametersConfig.SpeedPeople;
            }
            dataGridView1.RowCount = _coordinate.Count();
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1[0, i].Value = i;
                dataGridView1[1, i].Value = _coordinate[i];
                dataGridView1[2, i].Value = _speed[i];
            }
        }

        private void SaveData(int index)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                _coordinate[i] = Convert.ToDouble(dataGridView1[1, i].Value, CultureInfo.GetCultureInfo("en-US")).ToString(CultureInfo.GetCultureInfo("en-US")); ;
                _speed[i] = Convert.ToDouble(dataGridView1[2, i].Value, CultureInfo.GetCultureInfo("en-US")).ToString(CultureInfo.GetCultureInfo("en-US")); ;
            }
            if (index == 0x2035)
            {
                IoC.Resolve<MineConfig>().ParametersConfig.CoordinateRevision = _coordinate;
                IoC.Resolve<MineConfig>().ParametersConfig.SpeedRevision = _speed;
            }
            else if (index == 0x2036)
            {
                IoC.Resolve<MineConfig>().ParametersConfig.CoordinateVeight = _coordinate;
                IoC.Resolve<MineConfig>().ParametersConfig.SpeedVeight = _speed;
            }
            else if (index == 0x2037)
            {
                IoC.Resolve<MineConfig>().ParametersConfig.CoordinateEquipment = _coordinate;
                IoC.Resolve<MineConfig>().ParametersConfig.SpeedEquipment = _speed;
            }
            else if (index == 0x2038)
            {
                IoC.Resolve<MineConfig>().ParametersConfig.CoordinatePeople = _coordinate;
                IoC.Resolve<MineConfig>().ParametersConfig.SpeedPeople = _speed;
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            SaveData(_index);
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            tb.KeyPress -= tb_KeyPress;
            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }

        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            string vlCell = ((TextBox)sender).Text;
            //проверка ввода
            if (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].IsInEditMode == true)
                if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '\b') && (e.KeyChar != '-'))
                    e.Handled = true;
            if (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].IsInEditMode == true)
                if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '\b') && (e.KeyChar != '-'))
                    e.Handled = true;
        }

        private void MakeGraphic()
        {
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
                double[] x = new double[dataGridView1.RowCount];
                for (int j = 0; j < dataGridView1.RowCount; j++)
                    x[j] = Convert.ToDouble(dataGridView1[2, j].Value);
                System.Array.Sort(x);
                double max = x[x.Length - 1];
                var yAxis = new LinearAxis(AxisPosition.Left, 0)
                {
                    MajorGridlineStyle = LineStyle.Solid,
                    MinorGridlineStyle = LineStyle.Dot,
                    Title = "Скорость (м/с)",
                    Minimum = 0,
                    Maximum = 1.2 * max
                };
                plotDefenceDiagram.Model.Axes.Add(yAxis);
                // Create Line series
                var s1 = new LineSeries { StrokeThickness = 1, Color = OxyColors.Blue };
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    s1.Points.Add(new DataPoint(Convert.ToDouble(dataGridView1[1, i].Value, CultureInfo.GetCultureInfo("en-US")),
                        Convert.ToDouble(dataGridView1[2, i].Value, CultureInfo.GetCultureInfo("en-US"))));
                }
                // add Series and Axis to plot model
                plotDefenceDiagram.Model.Series.Add(s1);
            }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1[1, i].Value == null || dataGridView1[1, i].Value.ToString() == ".")
                        dataGridView1[1, i].Value = 0;
                }
            }
            if (e.ColumnIndex == 2)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1[2, i].Value == null || dataGridView1[2, i].Value.ToString() == ".")
                        dataGridView1[2, i].Value = 0;
                }
            }
            //
            plotDefenceDiagram.Dispose();
            plotDefenceDiagram = new OxyPlot.WindowsForms.Plot { Model = new PlotModel(), Dock = DockStyle.Fill };
            this.splitContainer2.Panel2.Controls.Add(plotDefenceDiagram);
            MakeGraphic();
        }

    }
}
