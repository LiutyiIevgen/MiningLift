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
using VisualizationSystem.Model;

namespace VisualizationSystem.View.UserControls.GeneralView
{
    public partial class CycleUC : UserControl
    {
        public CycleUC()
        {
            InitializeComponent();
            for (int i = 0; i < checkedListBoxGraphic.Items.Count; i++)
                checkedListBoxGraphic.SetItemChecked(i, true);
            _mineConfig = IoC.Resolve<MineConfig>();
        }
        private void SetGraphicInterval()
        {
            this.Invoke((MethodInvoker)delegate
            {
                chartVA.ChartAreas[0].AxisX.Minimum = -_mineConfig.MainViewConfig.Border.Value;
                chartVA.ChartAreas[0].AxisX.Maximum = -_mineConfig.MainViewConfig.BorderZero.Value;
                chartVA.ChartAreas[0].AxisX.Interval = _mineConfig.MainViewConfig.Distance.Value / 8;
                chartVA.ChartAreas[0].AxisY.Minimum = -100;
                chartVA.ChartAreas[0].AxisY.Maximum = 125;
                chartVA.ChartAreas[0].AxisY.Interval = 25;
            });
        }
        public void Refresh(Parameters parameters)
        {
            SetGraphicInterval();
            var param = parameters as Parameters;
            if (param.f_start == 1 || param.f_back == 1)
            {
                //var defenceDiagramVm = new DefenceDiagramVm(param);
                if (param.f_ostanov == 1)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        chartVA.Series[0].Points.Clear();
                        chartVA.Series[1].Points.Clear();
                        chartVA.Series[2].Points.Clear();
                        //chartVA.Series[3].Points.Clear();
                    });
                }
                this.Invoke((MethodInvoker)delegate
                {
                    chartVA.Series[0].Points.AddXY(-param.s,
                        param.v / (_mineConfig.MainViewConfig.MaxSpeed.Value / 100));
                    chartVA.Series[1].Points.AddXY(-param.s,
                        param.tok_anchor / (_mineConfig.MainViewConfig.MaxTokAnchor.Value / 100));
                    chartVA.Series[2].Points.AddXY(-param.s,
                        param.tok_excitation / (_mineConfig.MainViewConfig.MaxTokExcitation.Value / 100));
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
        }

        private MineConfig _mineConfig;
    }
}
