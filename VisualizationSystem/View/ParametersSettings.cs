﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ML.ConfigSettings.Services;
using ML.DataExchange;
using VisualizationSystem.Model;

namespace VisualizationSystem.View
{
    public partial class ParametersSettings : UserControl
    {
        static int variableParametersCount = 0;
        static int readonlyParametersCount = 0;
        string[] variableParametersName = null;
        string[] variableParametersValue = null;
        string[] variableParametersType = null;
        string[] readonlyParametersName = null;
        string[] readonlyParametersValue = null;
        double calculatedWayVeightAndEquipment = 0;
        double calculatedWayPeople = 0;
        double dotWayVeightAndEquipment = 0;
        double dotWayPeople = 0;
        //List<int> _indexes = new List<int>();
        private int _contextMenuClickedRow = 0;
        private int _contextMenuClickedColumn = 0;
        int startIndex = 0x2001;//8193;

        public ParametersSettings()
        {
            InitializeComponent();
            IoC.Resolve<DataListener>().SetParameterReceive(ParameterReceive);
        }

        private void ParametersSettings_Load(object sender, EventArgs e)
        {
            InitData();
            ParamLog.Clear();
            comboBoxControllerID.SelectedIndex = 0;
        }

        private void InitData()
        {
            variableParametersName = IoC.Resolve<MineConfig>().ParametersConfig.VariableParametersName;
            variableParametersValue = IoC.Resolve<MineConfig>().ParametersConfig.VariableParametersValue;
            variableParametersType = IoC.Resolve<MineConfig>().ParametersConfig.VariableParametersType;
            readonlyParametersName = IoC.Resolve<MineConfig>().ParametersConfig.ReadonlyParametersName;
            readonlyParametersValue = IoC.Resolve<MineConfig>().ParametersConfig.ReadonlyParametersValue;

            variableParametersCount = variableParametersName.Count();
            readonlyParametersCount = readonlyParametersName.Count();
            dataGridViewVariableParameters.RowCount = variableParametersCount;
            dataGridViewReadOnlyParameters.RowCount = readonlyParametersCount;
            for (int i = 0; i < dataGridViewVariableParameters.RowCount; i++)
            {
                dataGridViewVariableParameters[0, i].Value = i;
                dataGridViewVariableParameters[1, i].Value = "0x" + Convert.ToString(startIndex + i, 16);
                dataGridViewVariableParameters[2, i].Value = variableParametersName[i];
                dataGridViewVariableParameters[3, i].Value = variableParametersType[i];
                dataGridViewVariableParameters[4, i].Value = variableParametersValue[i];
            }
            for (int i = 0; i < dataGridViewReadOnlyParameters.RowCount; i++)
            {
                dataGridViewReadOnlyParameters[0, i].Value = i;
                dataGridViewReadOnlyParameters[2, i].Value = readonlyParametersName[i];
                dataGridViewReadOnlyParameters[3, i].Value = readonlyParametersValue[i];
            }
            CalculateParameters();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            string[] newVariableParametersName = new string[variableParametersCount];
            string[] newVariableParametersValue = new string[variableParametersCount];
            string[] newVariableParametersType = new string[variableParametersCount];
            string[] newReadonlyParametersName = new string[readonlyParametersCount];
            string[] newReadonlyParametersValue = new string[readonlyParametersCount];

            for (int i = 0; i < dataGridViewVariableParameters.RowCount; i++)
            {
                newVariableParametersName[i] = dataGridViewVariableParameters[2, i].Value.ToString();
                newVariableParametersType[i] = dataGridViewVariableParameters[3, i].Value.ToString();
                newVariableParametersValue[i] = Convert.ToDouble(dataGridViewVariableParameters[4, i].Value, CultureInfo.GetCultureInfo("en-US")).ToString(CultureInfo.GetCultureInfo("en-US"));
            }
            for (int i = 0; i < dataGridViewReadOnlyParameters.RowCount; i++)
            {
                newReadonlyParametersName[i] = dataGridViewReadOnlyParameters[2, i].Value.ToString();
                newReadonlyParametersValue[i] = Convert.ToDouble(dataGridViewReadOnlyParameters[3, i].Value, CultureInfo.GetCultureInfo("en-US")).ToString(CultureInfo.GetCultureInfo("en-US"));
            }

            IoC.Resolve<MineConfig>().ParametersConfig.VariableParametersName = newVariableParametersName;
            IoC.Resolve<MineConfig>().ParametersConfig.VariableParametersType = newVariableParametersType;
            IoC.Resolve<MineConfig>().ParametersConfig.VariableParametersValue = newVariableParametersValue;
            IoC.Resolve<MineConfig>().ParametersConfig.ReadonlyParametersName = newReadonlyParametersName;
            IoC.Resolve<MineConfig>().ParametersConfig.ReadonlyParametersValue = newReadonlyParametersValue;
            InitData();
            AddLineToLog("Текущие названия и значения параметров сохранены ");
        }

        private void AddRowButton_Click(object sender, EventArgs e)
        {
            variableParametersCount++;
            dataGridViewVariableParameters.RowCount = variableParametersCount;
            dataGridViewVariableParameters[0, dataGridViewVariableParameters.RowCount - 1].Value = dataGridViewVariableParameters.RowCount - 1;
            dataGridViewVariableParameters[1, dataGridViewVariableParameters.RowCount - 1].Value = "0x" + Convert.ToString(startIndex + dataGridViewVariableParameters.RowCount - 1, 16);
            dataGridViewVariableParameters[2, dataGridViewVariableParameters.RowCount - 1].Value = dataGridViewVariableParameters.RowCount - 1;
            dataGridViewVariableParameters[3, dataGridViewVariableParameters.RowCount - 1].Value = " ";
            dataGridViewVariableParameters[4, dataGridViewVariableParameters.RowCount - 1].Value = 0;
            AddLineToLog("Добавлен новый параметр с индексом " + "0x" + Convert.ToString(startIndex + dataGridViewVariableParameters.RowCount - 1, 16));
        }

        private void dataGridViewVariableParameters_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            tb.KeyPress -= tb_KeyPress;
            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }
        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            string vlCell = ((TextBox)sender).Text;
            //bool temp = (vlCell.IndexOf(".") == -1);
            //проверка ввода
            if (dataGridViewVariableParameters.Rows[dataGridViewVariableParameters.CurrentRow.Index].Cells[2].IsInEditMode == true)
                if (e.KeyChar == '/')
                    e.Handled = true;
            if (dataGridViewVariableParameters.Rows[dataGridViewVariableParameters.CurrentRow.Index].Cells[3].IsInEditMode == true)
                if (e.KeyChar == '/')
                    e.Handled = true;
            if (dataGridViewVariableParameters.Rows[dataGridViewVariableParameters.CurrentRow.Index].Cells[4].IsInEditMode == true)
                if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '\b'))
                    e.Handled = true;
        }

        private void dataGridViewVariableParameters_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (e.RowIndex == 0)
                {
                    if (dataGridViewVariableParameters[4, 0].Value == null || dataGridViewVariableParameters[4, 0].Value.ToString() == ".")
                        dataGridViewVariableParameters[4, 0].Value = variableParametersValue[0];
                    else if (Convert.ToDouble(dataGridViewVariableParameters[4, 0].Value, CultureInfo.GetCultureInfo("en-US")) > 16 || Convert.ToDouble(dataGridViewVariableParameters[4, 0].Value, CultureInfo.GetCultureInfo("en-US")) <= 0)
                    {
                        dataGridViewVariableParameters[4, 0].Value = variableParametersValue[0];
                        MessageBox.Show(@"Vм ""груз"" (0-й параметр) должен быть больше 0 и меньше либо равен 16 м/с", "Ошибка ввода параметров", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                else if (e.RowIndex == 1)
                {
                    if (dataGridViewVariableParameters[4, 1].Value == null || dataGridViewVariableParameters[4, 1].Value.ToString() == ".")
                        dataGridViewVariableParameters[4, 1].Value = variableParametersValue[1];
                    else if (Convert.ToDouble(dataGridViewVariableParameters[4, 1].Value, CultureInfo.GetCultureInfo("en-US")) > 8 || Convert.ToDouble(dataGridViewVariableParameters[4, 1].Value, CultureInfo.GetCultureInfo("en-US")) <= 0)
                    {
                        dataGridViewVariableParameters[4, 1].Value = variableParametersValue[1];
                        MessageBox.Show(@"Vм ""люди"" (1-й параметр) должен быть больше 0 и меньше либо равен 8 м/с", "Ошибка ввода параметров", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                else if (e.RowIndex == 2)
                {
                    if (dataGridViewVariableParameters[4, 2].Value == null || dataGridViewVariableParameters[4, 2].Value.ToString() == ".")
                        dataGridViewVariableParameters[4, 2].Value = variableParametersValue[2];
                    else if (Convert.ToDouble(dataGridViewVariableParameters[4, 2].Value, CultureInfo.GetCultureInfo("en-US")) > 16 || Convert.ToDouble(dataGridViewVariableParameters[4, 2].Value, CultureInfo.GetCultureInfo("en-US")) <= 0)
                    {
                        dataGridViewVariableParameters[4, 2].Value = variableParametersValue[2];
                        MessageBox.Show(@"Vм ""оборудование"" (2-й параметр) должен быть больше 0 и меньше либо равен 16 м/с", "Ошибка ввода параметров", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                else if (e.RowIndex == 3)
                {
                    if (dataGridViewVariableParameters[4, 3].Value == null || dataGridViewVariableParameters[4, 3].Value.ToString() == ".")
                        dataGridViewVariableParameters[4, 3].Value = variableParametersValue[3];
                    else if (Convert.ToDouble(dataGridViewVariableParameters[4, 3].Value, CultureInfo.GetCultureInfo("en-US")) > 3 || Convert.ToDouble(dataGridViewVariableParameters[4, 3].Value, CultureInfo.GetCultureInfo("en-US")) <= 0)
                    {
                        dataGridViewVariableParameters[4, 3].Value = variableParametersValue[3];
                        MessageBox.Show(@"Vм ""ревизия"" (3-й параметр) должен быть больше 0 и меньше либо равен 3 м/с", "Ошибка ввода параметров", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                else if (e.RowIndex == 4)
                {
                    if (dataGridViewVariableParameters[4, 4].Value == null || dataGridViewVariableParameters[4, 4].Value.ToString() == ".")
                        dataGridViewVariableParameters[4, 4].Value = variableParametersValue[4];
                    else if (Convert.ToDouble(dataGridViewVariableParameters[4, 4].Value, CultureInfo.GetCultureInfo("en-US")) > 1.5 || Convert.ToDouble(dataGridViewVariableParameters[4, 4].Value, CultureInfo.GetCultureInfo("en-US")) <= 0)
                    {
                        dataGridViewVariableParameters[4, 4].Value = variableParametersValue[4];
                        MessageBox.Show(@"Vп ""груз и оборудование"" (4-й параметр) должен быть больше 0 и меньше либо равен 1.5 м/с", "Ошибка ввода параметров", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                else if (e.RowIndex == 5)
                {
                    if (dataGridViewVariableParameters[4, 5].Value == null || dataGridViewVariableParameters[4, 5].Value.ToString() == ".")
                        dataGridViewVariableParameters[4, 5].Value = variableParametersValue[5];
                    else if (Convert.ToDouble(dataGridViewVariableParameters[4, 5].Value, CultureInfo.GetCultureInfo("en-US")) > 1 || Convert.ToDouble(dataGridViewVariableParameters[4, 5].Value, CultureInfo.GetCultureInfo("en-US")) <= 0)
                    {
                        dataGridViewVariableParameters[4, 5].Value = variableParametersValue[5];
                        MessageBox.Show(@"Vп ""люди"" (5-й параметр) должен быть больше 0 и меньше либо равен 1 м/с", "Ошибка ввода параметров", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                else if (e.RowIndex == 6)
                {
                    if (dataGridViewVariableParameters[4, 6].Value == null || dataGridViewVariableParameters[4, 6].Value.ToString() == ".")
                        dataGridViewVariableParameters[4, 6].Value = variableParametersValue[6];
                    else if (Convert.ToDouble(dataGridViewVariableParameters[4, 6].Value, CultureInfo.GetCultureInfo("en-US")) > 0.8 || Convert.ToDouble(dataGridViewVariableParameters[4, 6].Value, CultureInfo.GetCultureInfo("en-US")) <= 0)
                    {
                        dataGridViewVariableParameters[4, 6].Value = variableParametersValue[6];
                        MessageBox.Show(@"Vд (6-й параметр) должен быть больше 0 и меньше либо равен 0.8 м/с", "Ошибка ввода параметров", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                else if (e.RowIndex == 7)
                {
                    if (dataGridViewVariableParameters[4, 7].Value == null || dataGridViewVariableParameters[4, 7].Value.ToString() == ".")
                        dataGridViewVariableParameters[4, 7].Value = variableParametersValue[7];
                    else if (Convert.ToDouble(dataGridViewVariableParameters[4, 7].Value, CultureInfo.GetCultureInfo("en-US")) > 1 || Convert.ToDouble(dataGridViewVariableParameters[4, 7].Value, CultureInfo.GetCultureInfo("en-US")) <= 0)
                    {
                        dataGridViewVariableParameters[4, 7].Value = variableParametersValue[7];
                        MessageBox.Show(@"tос (7-й параметр) должен быть больше 0 и меньше либо равен 1 с", "Ошибка ввода параметров", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                else if (e.RowIndex == 8)
                {
                    if (dataGridViewVariableParameters[4, 8].Value == null || dataGridViewVariableParameters[4, 8].Value.ToString() == ".")
                        dataGridViewVariableParameters[4, 8].Value = variableParametersValue[8];
                    else if (Convert.ToDouble(dataGridViewVariableParameters[4, 8].Value, CultureInfo.GetCultureInfo("en-US")) > 1 || Convert.ToDouble(dataGridViewVariableParameters[4, 8].Value, CultureInfo.GetCultureInfo("en-US")) <= 0)
                    {
                        dataGridViewVariableParameters[4, 8].Value = variableParametersValue[8];
                        MessageBox.Show(@"tср (8-й параметр) должен быть больше 0 и меньше либо равен 1 с", "Ошибка ввода параметров", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                else if (e.RowIndex == 9)
                {
                    if (dataGridViewVariableParameters[4, 9].Value == null || dataGridViewVariableParameters[4, 9].Value.ToString() == ".")
                        dataGridViewVariableParameters[4, 9].Value = variableParametersValue[9];
                }
                else if (e.RowIndex == 10)
                {
                    if (dataGridViewVariableParameters[4, 10].Value == null || dataGridViewVariableParameters[4, 10].Value.ToString() == ".")
                        dataGridViewVariableParameters[4, 10].Value = variableParametersValue[10];
                }
                else if (e.RowIndex == 11)
                {
                    if (dataGridViewVariableParameters[4, 11].Value == null || dataGridViewVariableParameters[4, 11].Value.ToString() == ".")
                        dataGridViewVariableParameters[4, 11].Value = variableParametersValue[11];
                    else if (Convert.ToDouble(dataGridViewVariableParameters[4, 11].Value, CultureInfo.GetCultureInfo("en-US")) > 4 || Convert.ToDouble(dataGridViewVariableParameters[4, 11].Value, CultureInfo.GetCultureInfo("en-US")) < 1.5)
                    {
                        dataGridViewVariableParameters[4, 11].Value = variableParametersValue[11];
                        MessageBox.Show(@"aпт ""груз и оборудование"" (11-й параметр) должен быть больше либо равен 1.5 и меньше либо равен 4 м/с2", "Ошибка ввода параметров", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                else if (e.RowIndex == 12)
                {
                    if (dataGridViewVariableParameters[4, 12].Value == null || dataGridViewVariableParameters[4, 12].Value.ToString() == ".")
                        dataGridViewVariableParameters[4, 12].Value = variableParametersValue[12];
                    else if (Convert.ToDouble(dataGridViewVariableParameters[4, 12].Value, CultureInfo.GetCultureInfo("en-US")) > 4 || Convert.ToDouble(dataGridViewVariableParameters[4, 12].Value, CultureInfo.GetCultureInfo("en-US")) < 1.5)
                    {
                        dataGridViewVariableParameters[4, 12].Value = variableParametersValue[12];
                        MessageBox.Show(@"aпт ""люди"" (12-й параметр) должен быть больше либо равен 1.5 и меньше либо равен 4 м/с2", "Ошибка ввода параметров", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                else if (e.RowIndex == 13)
                {
                    if (dataGridViewVariableParameters[4, 13].Value == null || dataGridViewVariableParameters[4, 13].Value.ToString() == ".")
                        dataGridViewVariableParameters[4, 13].Value = variableParametersValue[13];
                    else if (Convert.ToDouble(dataGridViewVariableParameters[4, 13].Value, CultureInfo.GetCultureInfo("en-US")) > 1.5 || Convert.ToDouble(dataGridViewVariableParameters[4, 13].Value, CultureInfo.GetCultureInfo("en-US")) < 0.3)
                    {
                        dataGridViewVariableParameters[4, 13].Value = variableParametersValue[13];
                        MessageBox.Show(@"aр ""груз и оборудование"" (13-й параметр) должен быть больше либо равен 0.3 и меньше либо равен 1.5 м/с2", "Ошибка ввода параметров", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                else if (e.RowIndex == 14)
                {
                    if (dataGridViewVariableParameters[4, 14].Value == null || dataGridViewVariableParameters[4, 14].Value.ToString() == ".")
                        dataGridViewVariableParameters[4, 14].Value = variableParametersValue[14];
                    else if (Convert.ToDouble(dataGridViewVariableParameters[3, 14].Value, CultureInfo.GetCultureInfo("en-US")) > 1.5 || Convert.ToDouble(dataGridViewVariableParameters[4, 14].Value, CultureInfo.GetCultureInfo("en-US")) < 0.3)
                    {
                        dataGridViewVariableParameters[4, 14].Value = variableParametersValue[14];
                        MessageBox.Show(@"aр ""люди"" (14-й параметр) должен быть больше либо равен 0.3 и меньше либо равен 1.5 м/с2", "Ошибка ввода параметров", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                else if (e.RowIndex == 15)
                {
                    if (dataGridViewVariableParameters[4, 15].Value == null || dataGridViewVariableParameters[4, 15].Value.ToString() == ".")
                        dataGridViewVariableParameters[4, 15].Value = variableParametersValue[15];
                    else if (Convert.ToDouble(dataGridViewVariableParameters[4, 15].Value, CultureInfo.GetCultureInfo("en-US")) > 1.5 || Convert.ToDouble(dataGridViewVariableParameters[4, 15].Value, CultureInfo.GetCultureInfo("en-US")) < 0.3)
                    {
                        dataGridViewVariableParameters[4, 15].Value = variableParametersValue[15];
                        MessageBox.Show(@"deltaV (15-й параметр) должен быть больше либо равен 0.3 и меньше либо равен 1.5 м/с", "Ошибка ввода параметров", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                else if (e.RowIndex > 15)
                {
                    for (int i = 16; i < 20; i++)
                    {
                        if (dataGridViewVariableParameters[4, i].Value == null || dataGridViewVariableParameters[4, i].Value.ToString() == ".")
                            dataGridViewVariableParameters[4, i].Value = variableParametersValue[i];
                    }
                    for (int i = 20; i < variableParametersCount; i++)
                    {
                        if (dataGridViewVariableParameters[4, i].Value == null || dataGridViewVariableParameters[4, i].Value.ToString() == ".")
                            dataGridViewVariableParameters[4, i].Value = 0;
                    }
                }
            }
            if (e.ColumnIndex == 2)
            {
                for (int i = 0; i < variableParametersCount; i++)
                {
                    if (dataGridViewVariableParameters[2, i].Value == null)
                        dataGridViewVariableParameters[2, i].Value = i;
                }
            }
            if (e.ColumnIndex == 3)
            {
                for (int i = 0; i < variableParametersCount; i++)
                {
                    if (dataGridViewVariableParameters[3, i].Value == null)
                        dataGridViewVariableParameters[3, i].Value = " ";
                }
            }
            if (e.ColumnIndex == 4)
            {
                CalculateParameters();
            }
        }

        private void CalculateParameters()
        {
            calculatedWayVeightAndEquipment = Convert.ToDouble(dataGridViewVariableParameters[4, 4].Value, CultureInfo.GetCultureInfo("en-US")) * (Convert.ToDouble(dataGridViewVariableParameters[4, 7].Value, CultureInfo.GetCultureInfo("en-US")) + Convert.ToDouble(dataGridViewVariableParameters[4, 8].Value, CultureInfo.GetCultureInfo("en-US")));
            calculatedWayVeightAndEquipment += Convert.ToDouble(dataGridViewVariableParameters[4, 15].Value, CultureInfo.GetCultureInfo("en-US")) * Convert.ToDouble(dataGridViewVariableParameters[4, 8].Value, CultureInfo.GetCultureInfo("en-US")) / 2;
            calculatedWayVeightAndEquipment += (Convert.ToDouble(dataGridViewVariableParameters[4, 4].Value, CultureInfo.GetCultureInfo("en-US")) + Convert.ToDouble(dataGridViewVariableParameters[4, 15].Value, CultureInfo.GetCultureInfo("en-US"))) * (Convert.ToDouble(dataGridViewVariableParameters[4, 4].Value, CultureInfo.GetCultureInfo("en-US")) + Convert.ToDouble(dataGridViewVariableParameters[4, 15].Value, CultureInfo.GetCultureInfo("en-US"))) / (2 * Convert.ToDouble(dataGridViewVariableParameters[4, 11].Value, CultureInfo.GetCultureInfo("en-US")));
            dataGridViewReadOnlyParameters[3, 0].Value = Math.Round(calculatedWayVeightAndEquipment, 2);
            calculatedWayPeople = Convert.ToDouble(dataGridViewVariableParameters[4, 5].Value, CultureInfo.GetCultureInfo("en-US")) * (Convert.ToDouble(dataGridViewVariableParameters[4, 7].Value, CultureInfo.GetCultureInfo("en-US")) + Convert.ToDouble(dataGridViewVariableParameters[4, 8].Value, CultureInfo.GetCultureInfo("en-US")));
            calculatedWayPeople += Convert.ToDouble(dataGridViewVariableParameters[4, 15].Value, CultureInfo.GetCultureInfo("en-US")) * Convert.ToDouble(dataGridViewVariableParameters[4, 8].Value, CultureInfo.GetCultureInfo("en-US")) / 2;
            calculatedWayPeople += (Convert.ToDouble(dataGridViewVariableParameters[4, 5].Value, CultureInfo.GetCultureInfo("en-US")) + Convert.ToDouble(dataGridViewVariableParameters[4, 15].Value, CultureInfo.GetCultureInfo("en-US"))) * (Convert.ToDouble(dataGridViewVariableParameters[4, 5].Value, CultureInfo.GetCultureInfo("en-US")) + Convert.ToDouble(dataGridViewVariableParameters[4, 15].Value, CultureInfo.GetCultureInfo("en-US"))) / (2 * Convert.ToDouble(dataGridViewVariableParameters[4, 12].Value, CultureInfo.GetCultureInfo("en-US")));
            dataGridViewReadOnlyParameters[3, 1].Value = Math.Round(calculatedWayPeople, 2);
            dotWayVeightAndEquipment = calculatedWayVeightAndEquipment + Convert.ToDouble(dataGridViewVariableParameters[4, 9].Value, CultureInfo.GetCultureInfo("en-US")) + Convert.ToDouble(dataGridViewVariableParameters[4, 10].Value, CultureInfo.GetCultureInfo("en-US"));
            dataGridViewReadOnlyParameters[3, 2].Value = Math.Round(dotWayVeightAndEquipment, 2);
            dotWayPeople = calculatedWayPeople + Convert.ToDouble(dataGridViewVariableParameters[4, 9].Value, CultureInfo.GetCultureInfo("en-US")) + Convert.ToDouble(dataGridViewVariableParameters[4, 10].Value, CultureInfo.GetCultureInfo("en-US"));
            dataGridViewReadOnlyParameters[3, 3].Value = Math.Round(dotWayPeople, 2);
            AddLineToLog("Расчётные параметры пересчитаны ");
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddLineToLog("Загрузка параметра с индексом "+"0x"+Convert.ToString(startIndex + _contextMenuClickedRow, 16));
            LoadParameter(startIndex + _contextMenuClickedRow, _contextMenuClickedColumn - 2);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AddLineToLog("Старт выгрузки параметра с индексом " + "0x" + Convert.ToString(startIndex + _contextMenuClickedRow, 16));
            UnloadParameter(startIndex + _contextMenuClickedRow, _contextMenuClickedColumn - 2);
        }

        private void LoadParameter(int index, int subindex) //загрузка
        {
            byte[] data=null;
            try
            {
                if (ReadDataFromParametersTable(index, 1) == "codtReal32")
                {
                    var nfi = new NumberFormatInfo();
                    nfi.NumberDecimalSeparator = ".";
                    string sf = ReadDataFromParametersTable(index, subindex);
                    float f = float.Parse(sf, nfi);
                    data = BitConverter.GetBytes(f);
                }
                else if (ReadDataFromParametersTable(index, 1) == "codtSInt16")
                {
                    string ssh = ReadDataFromParametersTable(index, subindex);
                    short sh = short.Parse(ssh);
                    data = BitConverter.GetBytes(sh);
                }
                IoC.Resolve<DataListener>().SetParameter((ushort) index, (byte) subindex, data);
            }
            catch (Exception)
            {
                
            }
        }

        private void UnloadParameter(int index,int subindex)//выгрузка
        {
            IoC.Resolve<DataListener>().GetParameter((ushort)index, (byte)subindex);
        }

        private void ParameterReceive(List<CanParameter> parametersList)
        {
            
            foreach (var canParameter in parametersList)
            {
                if (canParameter.Data.Count() == 4)//real 32
                {
                    float myFloat;
                    myFloat = System.BitConverter.ToSingle(canParameter.Data, 0);
                    var nfi = new NumberFormatInfo();
                    nfi.NumberDecimalSeparator = ".";
                    string strData = myFloat.ToString(nfi);
                    WriteDataToParametersTable(canParameter.ParameterId, canParameter.ParameterSubIndex, strData);
                }
                else if (canParameter.Data.Count() == 2)//sint16
                {
                    short myShort;
                    myShort = System.BitConverter.ToInt16(canParameter.Data, 0); ;
                    WriteDataToParametersTable(canParameter.ParameterId, canParameter.ParameterSubIndex, myShort.ToString());
                }
                else if (canParameter.Data.Count() == 3)//sint24
                {
                    int myShort;
                    myShort = (canParameter.Data[0] << 8) + (canParameter.Data[1] << 16) + (canParameter.Data[2] << 24);
                    myShort /= 256;
                    WriteDataToParametersTable(canParameter.ParameterId, canParameter.ParameterSubIndex, myShort.ToString());
                }
                
            }
            
        }
        private void dataGridViewVariableParameters_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                _contextMenuClickedRow = e.RowIndex;
                _contextMenuClickedColumn = e.ColumnIndex;
                if (dataGridViewVariableParameters[3, _contextMenuClickedRow].Value.ToString() == "codtDomain")
                {
                    toolStripMenuItem1.Visible = false;
                    toolStripMenuItem2.Visible = true;
                    toolStripMenuItem3.Visible = true;
                }
                else
                {
                    toolStripMenuItem1.Visible = true;
                    toolStripMenuItem2.Visible = true;
                    toolStripMenuItem3.Visible = false;   
                }
            }
        }

        private void WriteDataToParametersTable(int index, int subindex, string value)
        {
            AddLineToLog("Выгружен параметр с индексом " + "0x" + Convert.ToString(startIndex + _contextMenuClickedRow, 16));
            dataGridViewVariableParameters[subindex + 2, index - startIndex].Value = value;
        }

        private string ReadDataFromParametersTable(int index, int subindex)
        {
            string value;
            value = dataGridViewVariableParameters[subindex + 2, index - startIndex].Value.ToString();
            return value;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            AddLineToLog("Открыто окно редактирования параметра с индексом " + "0x" + Convert.ToString(startIndex + _contextMenuClickedRow, 16));
            FormCodtDomainParamType f4 = new FormCodtDomainParamType(startIndex + _contextMenuClickedRow);
            f4.ShowDialog();
        }

        private void AddLineToLog(string text)
        {
            ParamLog.Text += DateTime.Now.ToShortDateString() + "   " + DateTime.Now.ToLongTimeString() + "     " + text + "\n";
        }
    }
}
