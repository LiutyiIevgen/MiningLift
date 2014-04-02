using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ML.DataExchange.Model;
using VisualizationSystem.Model;
using VisualizationSystem.Model.Settings;
using VisualizationSystem.View.Forms;
using VisualizationSystem.View.Forms.Setting;

namespace VisualizationSystem.View.UserControls.Setting
{
    public partial class KalibrovkaSettings : UserControl
    {
        public KalibrovkaSettings()
        {
            InitializeComponent();
            IoC.Resolve<DataListener>().SetParameterReceive(ParameterReceive);
            unloadThread = new Thread(UnloadAllParameters) { IsBackground = true };
        }

        private void KalibrovkaSettings_Load(object sender, EventArgs e)
        {

        }

        private void UnloadParameter(ushort controllerId, int index)//выгрузка
        {
            _kalibrovkaOperation = 1;
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

        private void ParameterReceive(List<CanParameter> parametersList)
        {
            if (_kalibrovkaOperation == 1)
            {
                foreach (var canParameter in parametersList)
                {
                    if (canParameter.Data == null) //parameter was seted
                    {
                        _isLoaded.Set();
                        continue;
                    }
                    switch (canParameter.ParameterSubIndex)
                    {
                        case (byte) CanSubindexes.Value:
                            _isUnloaded.Set();
                            ValueParser(canParameter);
                            break;
                    }
                }
                _kalibrovkaOperation = 0;
            }
        }

        private void ValueParser(CanParameter canParameter)
        {
            if (canParameter.Data.Count() == 4)//real 32
            {
                float myFloat;
                myFloat = System.BitConverter.ToSingle(canParameter.Data, 0);
                var nfi = new NumberFormatInfo();
                nfi.NumberDecimalSeparator = ".";
                string strData = myFloat.ToString(nfi);
                WriteDataToTextBox(canParameter.ParameterId, canParameter.ControllerId, strData);
            }
            else if (canParameter.Data.Count() == 3) //sint24
            {
                int myShort;
                myShort = (canParameter.Data[0] << 8) + (canParameter.Data[1] << 16) + (canParameter.Data[2] << 24);
                myShort /= 256;
                WriteDataToTextBox(canParameter.ParameterId, canParameter.ControllerId, myShort.ToString());
            }
        }

        private void WriteDataToTextBox(int index, ushort ControllerId, string value)
        {
            this.Invoke((MethodInvoker) delegate
            {
                if (index == startIndex + 1)
                {
                    switch (ControllerId)
                    {
                        case 1:
                            textBoxCounter1_1.Text = value;
                            break;
                        case 2:
                            textBoxCounter1_2.Text = value;
                            break;
                        case 3:
                            textBoxCounter1_3.Text = value;
                            break;
                    }
                }
                else if (index == startIndex + 3)
                {
                    switch (ControllerId)
                    {
                        case 1:
                            textBoxMS1.Text = value;
                            break;
                        case 2:
                            textBoxMS2.Text = value;
                            break;
                        case 3:
                            textBoxMS3.Text = value;
                            break;
                    }
                }
            });
        }

        private void buttonReadAll_Click(object sender, EventArgs e)
        {
            if (unloadThread.IsAlive)
                return;
            unloadThread = new Thread(UnloadAllParameters) { IsBackground = true };
            unloadThread.Start();
        }

        private void UnloadAllParameters()
        {
                int j = 1;
                while (j < 4)
                {
                    Thread.Sleep(200);
                    UnloadParameter((ushort)j, startIndex + 1);
                    if (!_isUnloaded.WaitOne(TimeSpan.FromMilliseconds(10000)))
                        return;
                    j++;
                }
                j = 1;
                while (j < 4)
                {
                    Thread.Sleep(200);
                    UnloadParameter((ushort)j, startIndex + 3);
                    if (!_isUnloaded.WaitOne(TimeSpan.FromMilliseconds(10000)))
                        return;
                    j++;
                }
        }

        private int startIndex = 0x2000;
        private Thread unloadThread;
        EventWaitHandle _isUnloaded = new AutoResetEvent(false);
        EventWaitHandle _isLoaded = new AutoResetEvent(false);
        private int _kalibrovkaOperation = 0; // flag

    }
}
