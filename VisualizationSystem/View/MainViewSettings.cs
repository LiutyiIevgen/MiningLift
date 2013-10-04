using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ML.ConfigSettings.Model;
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

            leftSosudСomboBox.SelectedIndex = Convert.ToInt32(IoC.Resolve<MineConfig>().MainViewConfig.LeftSosud);
            rightSosudComboBox.SelectedIndex = Convert.ToInt32(IoC.Resolve<MineConfig>().MainViewConfig.RightSosud);
        }

        private void maxSpeedTextBox_TextChanged(object sender, EventArgs e)
        {
            if (maxSpeedTextBox.Text == "" || maxSpeedTextBox.Text == ".")
                IoC.Resolve<MineConfig>().MainViewConfig.MaxSpeed.Value = 0;
            else if (Convert.ToDouble(maxSpeedTextBox.Text, CultureInfo.GetCultureInfo("en-US")) > 16)
            {
                IoC.Resolve<MineConfig>().MainViewConfig.MaxSpeed.Value = 16;
                maxSpeedTextBox.Text = Convert.ToString(16, CultureInfo.GetCultureInfo("en-US"));
                MessageBox.Show("Масштаб скорости не может быть больше 16 м/с", "Ошибка ввода параметров", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
                IoC.Resolve<MineConfig>().MainViewConfig.MaxSpeed.Value = Convert.ToDouble(maxSpeedTextBox.Text, CultureInfo.GetCultureInfo("en-US"));
        }

        private void maxDopRuleSpeedTextBox_TextChanged(object sender, EventArgs e)
        {
            if (maxDopRuleSpeedTextBox.Text == "" || maxDopRuleSpeedTextBox.Text == ".")
                IoC.Resolve<MineConfig>().MainViewConfig.MaxDopRuleSpeed.Value = 0;
            else if (Convert.ToDouble(maxDopRuleSpeedTextBox.Text, CultureInfo.GetCultureInfo("en-US")) > 16)
            {
                IoC.Resolve<MineConfig>().MainViewConfig.MaxDopRuleSpeed.Value = 16;
                maxDopRuleSpeedTextBox.Text = Convert.ToString(16, CultureInfo.GetCultureInfo("en-US"));
                MessageBox.Show("Макс. скорость доп. шкалы не может быть больше 16 м/с", "Ошибка ввода параметров", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
                IoC.Resolve<MineConfig>().MainViewConfig.MaxDopRuleSpeed.Value = Convert.ToDouble(maxDopRuleSpeedTextBox.Text, CultureInfo.GetCultureInfo("en-US"));
        }

        private void maxTokAnchorTextBox_TextChanged(object sender, EventArgs e)
        {
            if (maxTokAnchorTextBox.Text == "" || maxTokAnchorTextBox.Text == ".")
                IoC.Resolve<MineConfig>().MainViewConfig.MaxTokAnchor.Value = 0;
            else if (Convert.ToDouble(maxTokAnchorTextBox.Text, CultureInfo.GetCultureInfo("en-US")) > 8)
            {
                IoC.Resolve<MineConfig>().MainViewConfig.MaxTokAnchor.Value = 8;
                maxTokAnchorTextBox.Text = Convert.ToString(8, CultureInfo.GetCultureInfo("en-US"));
                MessageBox.Show("Масштаб тока якоря не может быть больше 8 кА", "Ошибка ввода параметров", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
                IoC.Resolve<MineConfig>().MainViewConfig.MaxTokAnchor.Value = Convert.ToDouble(maxTokAnchorTextBox.Text, CultureInfo.GetCultureInfo("en-US"));
        }

        private void maxTokExcitationTextBox_TextChanged(object sender, EventArgs e)
        {
            if (maxTokExcitationTextBox.Text == "" || maxTokExcitationTextBox.Text == ".")
                IoC.Resolve<MineConfig>().MainViewConfig.MaxTokExcitation.Value = 0;
            else if (Convert.ToDouble(maxTokExcitationTextBox.Text, CultureInfo.GetCultureInfo("en-US")) > 400)
            {
                IoC.Resolve<MineConfig>().MainViewConfig.MaxTokExcitation.Value = 400;
                maxTokExcitationTextBox.Text = Convert.ToString(400, CultureInfo.GetCultureInfo("en-US"));
                MessageBox.Show("Масштаб тока возбуждения не может быть больше 400 А", "Ошибка ввода параметров", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
                IoC.Resolve<MineConfig>().MainViewConfig.MaxTokExcitation.Value = Convert.ToDouble(maxTokExcitationTextBox.Text, CultureInfo.GetCultureInfo("en-US"));
        }

        private void distanceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (distanceTextBox.Text == "" || distanceTextBox.Text == ".")
                IoC.Resolve<MineConfig>().MainViewConfig.Distance.Value = 0;
            else if (Convert.ToDouble(distanceTextBox.Text, CultureInfo.GetCultureInfo("en-US")) > 1500)
            {
                IoC.Resolve<MineConfig>().MainViewConfig.Distance.Value = 1500;
                distanceTextBox.Text = Convert.ToString(1500, CultureInfo.GetCultureInfo("en-US"));
                MessageBox.Show("Глубина не может быть больше 1500 м", "Ошибка ввода параметров", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
                IoC.Resolve<MineConfig>().MainViewConfig.Distance.Value = Convert.ToDouble(distanceTextBox.Text, CultureInfo.GetCultureInfo("en-US"));
        }

        private void borderTextBox_TextChanged(object sender, EventArgs e)
        {
            if (borderTextBox.Text == "" || borderTextBox.Text == ".")
                IoC.Resolve<MineConfig>().MainViewConfig.Border.Value = 0;
            else if (Convert.ToDouble(borderTextBox.Text, CultureInfo.GetCultureInfo("en-US")) > IoC.Resolve<MineConfig>().MainViewConfig.Distance.Value)
            {
                IoC.Resolve<MineConfig>().MainViewConfig.Border.Value = IoC.Resolve<MineConfig>().MainViewConfig.Distance.Value;
                borderTextBox.Text = Convert.ToString(IoC.Resolve<MineConfig>().MainViewConfig.Distance.Value, CultureInfo.GetCultureInfo("en-US"));
                MessageBox.Show("Точка стопорения внизу не может быть больше глубины", "Ошибка ввода параметров", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
                IoC.Resolve<MineConfig>().MainViewConfig.Border.Value = Convert.ToDouble(borderTextBox.Text, CultureInfo.GetCultureInfo("en-US"));
        }

        private void borderZeroTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (borderZeroTextBox.Text == "" || borderZeroTextBox.Text == "." || borderZeroTextBox.Text == "-")
                    IoC.Resolve<MineConfig>().MainViewConfig.BorderZero.Value = 0;
                else
                    IoC.Resolve<MineConfig>().MainViewConfig.BorderZero.Value = Convert.ToDouble(borderZeroTextBox.Text, CultureInfo.GetCultureInfo("en-US"));
            }
            catch (Exception)
            {
                borderZeroTextBox.Text = "";
            }    
        }

        private void borderRedTextBox_TextChanged(object sender, EventArgs e)
        {
            if (borderRedTextBox.Text == "" || borderRedTextBox.Text == ".")
                IoC.Resolve<MineConfig>().MainViewConfig.BorderRed.Value = 0;
            else if (Convert.ToDouble(borderRedTextBox.Text, CultureInfo.GetCultureInfo("en-US")) > 1)
            {
                IoC.Resolve<MineConfig>().MainViewConfig.BorderRed.Value = 1;
                borderRedTextBox.Text = Convert.ToString(1, CultureInfo.GetCultureInfo("en-US"));
                MessageBox.Show("Переподъём не может быть больше 1 м", "Ошибка ввода параметров", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
                IoC.Resolve<MineConfig>().MainViewConfig.BorderRed.Value = Convert.ToDouble(borderRedTextBox.Text, CultureInfo.GetCultureInfo("en-US"));
        }

        private void upZeroZoneTextBox_TextChanged(object sender, EventArgs e)
        {
            if (upZeroZoneTextBox.Text == "" || upZeroZoneTextBox.Text == ".")
                IoC.Resolve<MineConfig>().MainViewConfig.UpZeroZone.Value = 0;
            else if (Convert.ToDouble(upZeroZoneTextBox.Text, CultureInfo.GetCultureInfo("en-US")) > 25)
            {
                IoC.Resolve<MineConfig>().MainViewConfig.UpZeroZone.Value = 25;
                upZeroZoneTextBox.Text = Convert.ToString(25, CultureInfo.GetCultureInfo("en-US"));
                MessageBox.Show("Зона переподъёма не может быть больше 25 м", "Ошибка ввода параметров", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
                IoC.Resolve<MineConfig>().MainViewConfig.UpZeroZone.Value = Convert.ToDouble(upZeroZoneTextBox.Text, CultureInfo.GetCultureInfo("en-US"));
        }

        //ограничения на ввод букв и символов
        private void maxSpeedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            e.Handled = !(char.IsDigit(c) || c == '.' || c == '\b');
        }

        private void borderZeroTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            e.Handled = !(char.IsDigit(c) || c == '.' || c == '\b' || c == '-');
        }

        //
        private void leftSosudСomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (rightSosudComboBox.SelectedIndex == 1 && leftSosudСomboBox.SelectedIndex == 1)
            {
                leftSosudСomboBox.SelectedIndex = 0;
                MessageBox.Show("Оба сосуда не могут быть противовесом", "Ошибка ввода параметров", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            } */
            IoC.Resolve<MineConfig>().MainViewConfig.LeftSosud = (SosudType)leftSosudСomboBox.SelectedIndex;
        }

        private void rightSosudComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (rightSosudComboBox.SelectedIndex == 1 && leftSosudСomboBox.SelectedIndex == 1)
            {
                rightSosudComboBox.SelectedIndex = 0;
                MessageBox.Show("Оба сосуда не могут быть противовесом", "Ошибка ввода параметров", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }*/
            IoC.Resolve<MineConfig>().MainViewConfig.RightSosud = (SosudType)rightSosudComboBox.SelectedIndex;
        }


    }
}
