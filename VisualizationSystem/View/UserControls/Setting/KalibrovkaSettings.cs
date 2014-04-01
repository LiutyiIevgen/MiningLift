using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualizationSystem.Model;
using VisualizationSystem.View.Forms;

namespace VisualizationSystem.View.UserControls.Setting
{
    public partial class KalibrovkaSettings : UserControl
    {
        public KalibrovkaSettings()
        {
            InitializeComponent();
        }

        private void KalibrovkaSettings_Load(object sender, EventArgs e)
        {

        }

        private void UnloadParameter(ushort controllerId, int index)//выгрузка
        {
            IoC.Resolve<DataListener>().GetParameter((ushort)controllerId, (ushort)index, (byte)CanSubindexes.Value);
        }

        private void LoadParameter(ushort controllerId, int index, int subindex, string value) //загрузка
        {
            List<byte> data = new List<byte>();
            try
            {
                if (subindex == 3 || subindex == 4 || subindex == 5)
                    {
                        var nfi = new NumberFormatInfo();
                        nfi.NumberDecimalSeparator = ".";
                        string sf = value;
                        float f = float.Parse(sf, nfi);
                        data.AddRange(BitConverter.GetBytes(f));
                    }
                else if (subindex == 1 || subindex == 2)
                    {
                        string ssh = value;
                        int sh = int.Parse(ssh);
                        var listData = BitConverter.GetBytes(sh).ToList();
                        listData.RemoveAt(listData.Count - 1);
                        data.AddRange(listData.ToArray());
                    }
                IoC.Resolve<DataListener>().SetParameter((ushort)controllerId, (ushort)index, (byte)CanSubindexes.Value, data.ToArray());
            }
            catch (Exception)
            {

            }
        }

    }
}
