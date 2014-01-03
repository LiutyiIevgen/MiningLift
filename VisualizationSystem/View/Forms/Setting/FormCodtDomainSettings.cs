using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ML.ConfigSettings.Services;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using VisualizationSystem.Model;

namespace VisualizationSystem.View.Forms.Setting
{
    public partial class FormCodtDomainSettings : Form
    {
        private int _index;
        private int startIndex = 0x2001;
        private OxyPlot.WindowsForms.Plot plotDefenceDiagram;
        private const int EndOfArray = 2147483647;
        public FormCodtDomainSettings()
        {
            InitializeComponent();
        }

        public FormCodtDomainSettings(int index)
        {
            InitializeComponent();
            this.Text = "0x" + Convert.ToString(index, 16) + "  " + IoC.Resolve<MineConfig>().ParametersConfig.VariableParametersName[index - startIndex];
            _index = index;
            LoadDataFromInitFile(_index);
            plotDefenceDiagram = new OxyPlot.WindowsForms.Plot { Model = new PlotModel(), Dock = DockStyle.Fill };
            this.splitContainer2.Panel2.Controls.Add(plotDefenceDiagram);
            MakeGraphic();
        }

        public FormCodtDomainSettings(int index, List<string> data)
        {
            InitializeComponent();
            this.Text = "0x" + Convert.ToString(index, 16) + "  " + IoC.Resolve<MineConfig>().ParametersConfig.VariableParametersName[index - startIndex];
            _index = index;
            LoadDataFromController(data);
            plotDefenceDiagram = new OxyPlot.WindowsForms.Plot { Model = new PlotModel(), Dock = DockStyle.Fill };
            this.splitContainer2.Panel2.Controls.Add(plotDefenceDiagram);
            MakeGraphic();
        }

        private void FormCodtDomainParamType_Load(object sender, EventArgs e)
        {

        }

        private void LoadDataFromInitFile(int index)
        {
            string[] coordinate = null;
            string[] speed = null;
            if (index == 0x2035)
            {
                coordinate = IoC.Resolve<MineConfig>().ParametersConfig.CoordinateRevision;
                speed = IoC.Resolve<MineConfig>().ParametersConfig.SpeedRevision;
            }
            else if (index == 0x2036)
            {
                coordinate = IoC.Resolve<MineConfig>().ParametersConfig.CoordinateVeight;
                speed = IoC.Resolve<MineConfig>().ParametersConfig.SpeedVeight;
            }
            else if (index == 0x2037)
            {
                coordinate = IoC.Resolve<MineConfig>().ParametersConfig.CoordinateEquipment;
                speed = IoC.Resolve<MineConfig>().ParametersConfig.SpeedEquipment;
            }
            else if (index == 0x2038)
            {
                coordinate = IoC.Resolve<MineConfig>().ParametersConfig.CoordinatePeople;
                speed = IoC.Resolve<MineConfig>().ParametersConfig.SpeedPeople;
            }
            dataGridView1.RowCount = coordinate.Count();
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1[0, i].Value = i;
                dataGridView1[1, i].Value = coordinate[i];
                dataGridView1[2, i].Value = speed[i];
            }
        }

        private void LoadDataFromController(List<string> data)
        {
            dataGridView1.RowCount = data.Count()/2;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1[0, i].Value = i;
                dataGridView1[1, i].Value = data[i*2];
                dataGridView1[2, i].Value = data[i*2 + 1];
            }
        }

        private void SaveDataToInitFile(int index)
        {
            var coordinate = new string[dataGridView1.RowCount];
            var speed = new string[dataGridView1.RowCount];
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                coordinate[i] = dataGridView1[1, i].Value.ToString();
                speed[i] = dataGridView1[2, i].Value.ToString();
            }
            if (index == 0x2035)
            {
                IoC.Resolve<MineConfig>().ParametersConfig.CoordinateRevision = coordinate;
                IoC.Resolve<MineConfig>().ParametersConfig.SpeedRevision = speed;
            }
            else if (index == 0x2036)
            {
                IoC.Resolve<MineConfig>().ParametersConfig.CoordinateVeight = coordinate;
                IoC.Resolve<MineConfig>().ParametersConfig.SpeedVeight = speed;
            }
            else if (index == 0x2037)
            {
                IoC.Resolve<MineConfig>().ParametersConfig.CoordinateEquipment = coordinate;
                IoC.Resolve<MineConfig>().ParametersConfig.SpeedEquipment = speed;
            }
            else if (index == 0x2038)
            {
                IoC.Resolve<MineConfig>().ParametersConfig.CoordinatePeople = coordinate;
                IoC.Resolve<MineConfig>().ParametersConfig.SpeedPeople = speed;
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            SaveDataToInitFile(_index);
            MessageBox.Show("Запись параметров в config файл успешно завершена!", "Сохранение параметров", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
            var valueList = new List<int>();
            foreach (DataGridViewRow row in  dataGridView1.Rows)
            {
                int value = int.Parse(row.Cells[1].Value.ToString());
                if (value != EndOfArray)
	                valueList.Add(value/1000);
            }
            //Axis
            var xAxis = new LinearAxis(AxisPosition.Bottom, 0)
            {
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Title = "Путь (м)",
                Maximum = -IoC.Resolve<MineConfig>().MainViewConfig.BorderZero.Value,
                Minimum = valueList.Min()+1
            };
            plotDefenceDiagram.Model.Axes.Add(xAxis);
            var yAxis = new LinearAxis(AxisPosition.Left, 0)
            {
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Title = "Скорость (м/с)",
            };
            plotDefenceDiagram.Model.Axes.Add(yAxis);
            // Create Line series
            var s1 = new LineSeries {StrokeThickness = 1, Color = OxyColors.Blue};
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToInt32(dataGridView1[1, i].Value) == EndOfArray)
                {
                    s1.Points.Add(
                        new DataPoint(
                            -IoC.Resolve<MineConfig>().MainViewConfig.BorderZero.Value,
                            Convert.ToDouble(dataGridView1[2, i].Value)/1000));
                    break;
                }
                s1.Points.Add(
                    new DataPoint(
                        Convert.ToDouble(dataGridView1[1, i].Value)/1000,
                        Convert.ToDouble(dataGridView1[2, i].Value)/1000));
            }
            // add Series and Axis to plot model
            plotDefenceDiagram.Model.Series.Add(s1);
            plotDefenceDiagram.RefreshPlot(true);
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

        private void toolStripButtonLoad_Click(object sender, EventArgs e) //load table
        {
            var data = new List<byte>();
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                string firstParamStr = dataGridView1[1, i].Value.ToString();
                int firstParam = int.Parse(firstParamStr);
                byte[] firstBytes= BitConverter.GetBytes(firstParam);
                data.AddRange(firstBytes);

                string secondParamStr = dataGridView1[2, i].Value.ToString();
                short secondParam = short.Parse(secondParamStr);
                byte[] secondBytes = BitConverter.GetBytes(secondParam);
                data.AddRange(secondBytes);
            }
            IoC.Resolve<DataListener>()
                .SetParameter((ushort)_index, 0x02, data.ToArray());
        }

    }
}
