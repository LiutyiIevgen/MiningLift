using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ML.ConfigSettings.Services;
using VisualizationSystem.Model;

namespace VisualizationSystem.View
{
    public partial class MainViewSettings : UserControl
    {
        public MainViewSettings()
        {
            InitializeComponent();
        }

        private void MainViewSettings_Load(object sender, EventArgs e)
        {
            maxSpeedTextBox.Text = Convert.ToString(IoC.Resolve<MineConfig>().MainViewConfig.MaxSpeed.Value, CultureInfo.GetCultureInfo("en-US"));
            maxDopRuleSpeedTextBox.Text = Convert.ToString(IoC.Resolve<MineConfig>().MainViewConfig.MaxDopRuleSpeed.Value, CultureInfo.GetCultureInfo("en-US"));
            maxTokAnchorTextBox.Text = Convert.ToString(IoC.Resolve<MineConfig>().MainViewConfig.MaxTokAnchor.Value, CultureInfo.GetCultureInfo("en-US"));
            maxTokExcitationTextBox.Text = Convert.ToString(IoC.Resolve<MineConfig>().MainViewConfig.MaxTokExcitation.Value, CultureInfo.GetCultureInfo("en-US"));
            distanceTextBox.Text = Convert.ToString(IoC.Resolve<MineConfig>().MainViewConfig.Distance.Value, CultureInfo.GetCultureInfo("en-US"));
            borderTextBox.Text = Convert.ToString(IoC.Resolve<MineConfig>().MainViewConfig.Border.Value, CultureInfo.GetCultureInfo("en-US"));
            borderZeroTextBox.Text = Convert.ToString(IoC.Resolve<MineConfig>().MainViewConfig.BorderZero.Value, CultureInfo.GetCultureInfo("en-US"));
            borderRedTextBox.Text = Convert.ToString(IoC.Resolve<MineConfig>().MainViewConfig.BorderRed.Value, CultureInfo.GetCultureInfo("en-US"));
            upZeroZoneTextBox.Text = Convert.ToString(IoC.Resolve<MineConfig>().MainViewConfig.UpZeroZone.Value, CultureInfo.GetCultureInfo("en-US"));
        }

        private void maxSpeedTextBox_TextChanged(object sender, EventArgs e)
        {
            if (maxSpeedTextBox.Text == "" || maxSpeedTextBox.Text == ".")
                IoC.Resolve<MineConfig>().MainViewConfig.MaxSpeed.Value = 0;
            else
                IoC.Resolve<MineConfig>().MainViewConfig.MaxSpeed.Value = Convert.ToDouble(maxSpeedTextBox.Text, CultureInfo.GetCultureInfo("en-US"));
        }

        private void maxDopRuleSpeedTextBox_TextChanged(object sender, EventArgs e)
        {
            if (maxDopRuleSpeedTextBox.Text == "" || maxDopRuleSpeedTextBox.Text == ".")
                IoC.Resolve<MineConfig>().MainViewConfig.MaxDopRuleSpeed.Value = 0;
            else
                IoC.Resolve<MineConfig>().MainViewConfig.MaxDopRuleSpeed.Value = Convert.ToDouble(maxDopRuleSpeedTextBox.Text, CultureInfo.GetCultureInfo("en-US"));
        }

        private void maxTokAnchorTextBox_TextChanged(object sender, EventArgs e)
        {
            if (maxTokAnchorTextBox.Text == "" || maxTokAnchorTextBox.Text == ".")
                IoC.Resolve<MineConfig>().MainViewConfig.MaxTokAnchor.Value = 0;
            else
                IoC.Resolve<MineConfig>().MainViewConfig.MaxTokAnchor.Value = Convert.ToDouble(maxTokAnchorTextBox.Text, CultureInfo.GetCultureInfo("en-US"));
        }

        private void maxTokExcitationTextBox_TextChanged(object sender, EventArgs e)
        {
            if (maxTokExcitationTextBox.Text == "" || maxTokExcitationTextBox.Text == ".")
                IoC.Resolve<MineConfig>().MainViewConfig.MaxTokExcitation.Value = 0;
            else
                IoC.Resolve<MineConfig>().MainViewConfig.MaxTokExcitation.Value = Convert.ToDouble(maxTokExcitationTextBox.Text, CultureInfo.GetCultureInfo("en-US"));
        }

        private void distanceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (distanceTextBox.Text == "" || distanceTextBox.Text == ".")
                IoC.Resolve<MineConfig>().MainViewConfig.Distance.Value = 0;
            else
                IoC.Resolve<MineConfig>().MainViewConfig.Distance.Value = Convert.ToDouble(distanceTextBox.Text, CultureInfo.GetCultureInfo("en-US"));
        }

        private void borderTextBox_TextChanged(object sender, EventArgs e)
        {
            if (borderTextBox.Text == "" || borderTextBox.Text == ".")
                IoC.Resolve<MineConfig>().MainViewConfig.Border.Value = 0;
            else
                IoC.Resolve<MineConfig>().MainViewConfig.Border.Value = Convert.ToDouble(borderTextBox.Text, CultureInfo.GetCultureInfo("en-US"));
        }

        private void borderZeroTextBox_TextChanged(object sender, EventArgs e)
        {
            if (borderZeroTextBox.Text == "" || borderZeroTextBox.Text == ".")
                IoC.Resolve<MineConfig>().MainViewConfig.BorderZero.Value = 0;
            else
                IoC.Resolve<MineConfig>().MainViewConfig.BorderZero.Value = Convert.ToDouble(borderZeroTextBox.Text, CultureInfo.GetCultureInfo("en-US"));
        }

        private void borderRedTextBox_TextChanged(object sender, EventArgs e)
        {
            if (borderRedTextBox.Text == "" || borderRedTextBox.Text == ".")
                IoC.Resolve<MineConfig>().MainViewConfig.BorderRed.Value = 0;
            else
                IoC.Resolve<MineConfig>().MainViewConfig.BorderRed.Value = Convert.ToDouble(borderRedTextBox.Text, CultureInfo.GetCultureInfo("en-US"));
        }

        private void upZeroZoneTextBox_TextChanged(object sender, EventArgs e)
        {
            if (upZeroZoneTextBox.Text == "" || upZeroZoneTextBox.Text == ".")
                IoC.Resolve<MineConfig>().MainViewConfig.UpZeroZone.Value = 0;
            else
                IoC.Resolve<MineConfig>().MainViewConfig.UpZeroZone.Value = Convert.ToDouble(upZeroZoneTextBox.Text, CultureInfo.GetCultureInfo("en-US"));
        }

        //ограничения на ввод букв и символов
        private void maxSpeedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            e.Handled = !(char.IsDigit(c) || c == '.' || c == '\b');
        }
    }
}
