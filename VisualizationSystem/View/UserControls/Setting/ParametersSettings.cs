using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ML.ConfigSettings.Services;
using ML.DataExchange;
using ML.DataExchange.Model;
using VisualizationSystem.Model;
using VisualizationSystem.Model.Settings;
using VisualizationSystem.View.Forms;
using VisualizationSystem.View.Forms.Setting;
using VisualizationSystem.ViewModel;

namespace VisualizationSystem.View.UserControls.Setting
{
    public partial class ParametersSettings : UserControl
    {
        public ParametersSettings()
        {
            InitializeComponent();
            IoC.Resolve<DataListener>().SetParameterReceive(ParameterReceive);
            _parametersSettingsVm = new ParametersSettingsVm();
        }

        private void ParametersSettings_Load(object sender, EventArgs e)
        {
            InitData();
            ParamLog.Clear();
        }

        private void InitData()
        {
            try
            {
                _parametersSettingsDatas = _parametersSettingsVm.ReadFromFile(IoC.Resolve<MineConfig>().ParametersConfig.ParametersFileName);
            }
            catch (Exception)
            {
                OpenFileFunction();
            }
            dataGridViewVariableParameters.RowCount = _parametersSettingsDatas.Count;
            for (int i = 0; i < dataGridViewVariableParameters.RowCount; i++)
            {
                dataGridViewVariableParameters[0, i].Value = i;
                dataGridViewVariableParameters[1, i].Value = "0x"+Convert.ToString(_parametersSettingsDatas[i].Id, 16);
                dataGridViewVariableParameters[2, i].Value = _parametersSettingsDatas[i].Name;
                dataGridViewVariableParameters[3, i].Value = _parametersSettingsDatas[i].Type;
                dataGridViewVariableParameters[4, i].Value = _parametersSettingsDatas[i].Value;
            }
           // CalculateParameters();
        }   

        private void CalculateParameters()
        {
            calculatedWayVeightAndEquipment = Convert.ToDouble(dataGridViewVariableParameters[4, 4].Value, CultureInfo.GetCultureInfo("en-US")) * (Convert.ToDouble(dataGridViewVariableParameters[4, 7].Value, CultureInfo.GetCultureInfo("en-US")) + Convert.ToDouble(dataGridViewVariableParameters[4, 8].Value, CultureInfo.GetCultureInfo("en-US")));
            calculatedWayVeightAndEquipment += Convert.ToDouble(dataGridViewVariableParameters[4, 15].Value, CultureInfo.GetCultureInfo("en-US")) * Convert.ToDouble(dataGridViewVariableParameters[4, 8].Value, CultureInfo.GetCultureInfo("en-US")) / 2;
            calculatedWayVeightAndEquipment += (Convert.ToDouble(dataGridViewVariableParameters[4, 4].Value, CultureInfo.GetCultureInfo("en-US")) + Convert.ToDouble(dataGridViewVariableParameters[4, 15].Value, CultureInfo.GetCultureInfo("en-US"))) * (Convert.ToDouble(dataGridViewVariableParameters[4, 4].Value, CultureInfo.GetCultureInfo("en-US")) + Convert.ToDouble(dataGridViewVariableParameters[4, 15].Value, CultureInfo.GetCultureInfo("en-US"))) / (2 * Convert.ToDouble(dataGridViewVariableParameters[4, 11].Value, CultureInfo.GetCultureInfo("en-US")));
            //dataGridViewReadOnlyParameters[3, 0].Value = Math.Round(calculatedWayVeightAndEquipment, 2);
            calculatedWayPeople = Convert.ToDouble(dataGridViewVariableParameters[4, 5].Value, CultureInfo.GetCultureInfo("en-US")) * (Convert.ToDouble(dataGridViewVariableParameters[4, 7].Value, CultureInfo.GetCultureInfo("en-US")) + Convert.ToDouble(dataGridViewVariableParameters[4, 8].Value, CultureInfo.GetCultureInfo("en-US")));
            calculatedWayPeople += Convert.ToDouble(dataGridViewVariableParameters[4, 15].Value, CultureInfo.GetCultureInfo("en-US")) * Convert.ToDouble(dataGridViewVariableParameters[4, 8].Value, CultureInfo.GetCultureInfo("en-US")) / 2;
            calculatedWayPeople += (Convert.ToDouble(dataGridViewVariableParameters[4, 5].Value, CultureInfo.GetCultureInfo("en-US")) + Convert.ToDouble(dataGridViewVariableParameters[4, 15].Value, CultureInfo.GetCultureInfo("en-US"))) * (Convert.ToDouble(dataGridViewVariableParameters[4, 5].Value, CultureInfo.GetCultureInfo("en-US")) + Convert.ToDouble(dataGridViewVariableParameters[4, 15].Value, CultureInfo.GetCultureInfo("en-US"))) / (2 * Convert.ToDouble(dataGridViewVariableParameters[4, 12].Value, CultureInfo.GetCultureInfo("en-US")));
            //dataGridViewReadOnlyParameters[3, 1].Value = Math.Round(calculatedWayPeople, 2);
            dotWayVeightAndEquipment = calculatedWayVeightAndEquipment + Convert.ToDouble(dataGridViewVariableParameters[4, 9].Value, CultureInfo.GetCultureInfo("en-US")) + Convert.ToDouble(dataGridViewVariableParameters[4, 10].Value, CultureInfo.GetCultureInfo("en-US"));
            //dataGridViewReadOnlyParameters[3, 2].Value = Math.Round(dotWayVeightAndEquipment, 2);
            dotWayPeople = calculatedWayPeople + Convert.ToDouble(dataGridViewVariableParameters[4, 9].Value, CultureInfo.GetCultureInfo("en-US")) + Convert.ToDouble(dataGridViewVariableParameters[4, 10].Value, CultureInfo.GetCultureInfo("en-US"));
            //dataGridViewReadOnlyParameters[3, 3].Value = Math.Round(dotWayPeople, 2);
            AddLineToLog("Расчётные параметры пересчитаны ");
        }  

        private void LoadParameter(int index, int subindex) //загрузка
        {
            byte[] data=null;
            try
            {
                if (subindex == 2) // you can write only value
                {
                    if (ReadDataFromParametersTable(index, 1) == "codtReal32")
                    {
                        var nfi = new NumberFormatInfo();
                        nfi.NumberDecimalSeparator = ".";
                        string sf = ReadDataFromParametersTable(index, subindex);
                        float f = float.Parse(sf, nfi);
                        data = BitConverter.GetBytes(f);
                    }
                    if (ReadDataFromParametersTable(index, 1) == "codtSInt24")
                    {
                        string ssh = ReadDataFromParametersTable(index, subindex);
                        int sh = int.Parse(ssh);
                        var listData = BitConverter.GetBytes(sh).ToList();
                        listData.RemoveAt(listData.Count - 1);
                        data = listData.ToArray();
                    }
                    else if (ReadDataFromParametersTable(index, 1) == "codtSInt16")
                    {
                        string ssh = ReadDataFromParametersTable(index, subindex);
                        short sh = short.Parse(ssh);
                        data = BitConverter.GetBytes(sh);
                    }
                    IoC.Resolve<DataListener>().SetParameter((ushort)index, (byte)subindex, data);
                }               
            }
            catch (Exception)
            {
                
            }
        }

        private void UnloadParameter(int index,int subindex)//выгрузка
        {
            switch (subindex)
            {
                case 2:
                    subindex = (int)CanSubindexes.Value;
                    break;
                case 1:
                    subindex = (int)CanSubindexes.Type;
                    break;
                case 0:
                    subindex = (int) CanSubindexes.Name;
                    break;
            }
            IoC.Resolve<DataListener>().GetParameter((ushort)index, (byte)subindex);
        }

        private void ParameterReceive(List<CanParameter> parametersList)
        {            
            foreach (var canParameter in parametersList)
            {
                if (canParameter.Data == null)//parameter was seted
                {
                    CanParameter parameter = canParameter;
                    this.Invoke((MethodInvoker)delegate
                    {
                        AddLineToLog("Загружен параметр с индексом " + "0x" +
                            Convert.ToString(parameter.ParameterId, 16) + ", address = " + 
                            Convert.ToString(parameter.ControllerId, 16));
                    });
                    continue;
                }
                switch (canParameter.ParameterSubIndex)
                {
                    case (byte)CanSubindexes.Value:
                        ValueParser(canParameter);
                        break;
                    case (byte)CanSubindexes.Name:
                        NamePareser(canParameter);
                        break;
                    case (byte)CanSubindexes.Type:
                        TypeParser(canParameter);
                        break;
                }
                CanParameter param = canParameter;
                this.Invoke((MethodInvoker)delegate
                    {
                        AddLineToLog("Выгружен параметр с индексом " + "0x" +
                            Convert.ToString(param.ParameterId, 16) + ", address = " +
                            Convert.ToString(param.ControllerId, 16));
                    });  
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
                    WriteDataToParametersTable(canParameter.ParameterId,2, strData);
                }
                else if (canParameter.Data.Count() == 2)//sint16
                {
                    short myShort;
                    myShort = BitConverter.ToInt16(canParameter.Data, 0);
                    WriteDataToParametersTable(canParameter.ParameterId,2, myShort.ToString());
                }
                else if (canParameter.Data.Count() == 3) //sint24
                {
                    int myShort;
                    myShort = (canParameter.Data[0] << 8) + (canParameter.Data[1] << 16) + (canParameter.Data[2] << 24);
                    myShort /= 256;
                    WriteDataToParametersTable(canParameter.ParameterId,2, myShort.ToString());
                }
                else //codtDomain
                {
                    var dataList = new List<string>();
                    int i = 0;
                    while (i < 20)
                    {
                        dataList.Add(BitConverter.ToInt32(canParameter.Data, i*6).ToString());
                        dataList.Add(BitConverter.ToInt16(canParameter.Data, i*6 + 4).ToString());
                        i++;
                    }
                    this.Invoke((MethodInvoker)delegate
                    {
                        var formDomain = new FormCodtDomainSettings(canParameter.ParameterId, dataList);
                        formDomain.Show();
                    });  
                }
        }

        private void NamePareser(CanParameter canParameter)
        {
            Encoding ansiCyrillic = Encoding.GetEncoding(1251);
            string name = ansiCyrillic.GetString(canParameter.Data, 0, canParameter.Data.Count());
            WriteDataToParametersTable(canParameter.ParameterId, 0, name);
        }

        private void TypeParser(CanParameter canParameter)
        {
            short myShort;
            myShort = BitConverter.ToInt16(canParameter.Data, 0);
            switch (myShort)
            {
                case 0x10:
                    WriteDataToParametersTable(canParameter.ParameterId, 1, "codtSInt24");
                    break;
                case 0xF:
                    WriteDataToParametersTable(canParameter.ParameterId, 1, "codtDomain");
                    break;
                case 8:
                    WriteDataToParametersTable(canParameter.ParameterId,1,"codtReal32");
                    break;
                case 3:
                    WriteDataToParametersTable(canParameter.ParameterId, 1, "codtSInt16");
                    break;
            }
        }

        private void AddLineToLog(string text)
        {
            ParamLog.Text += DateTime.Now.ToShortDateString() + "   " + DateTime.Now.ToLongTimeString() + "     " + text + "\n";
            ParamLog.SelectionStart = ParamLog.Text.Length; //Set the current caret position at the end
            ParamLog.ScrollToCaret(); //Now scroll it automatically
        }

        private void SaveParametersData()
        {
            for (int i = 0; i < dataGridViewVariableParameters.RowCount; i++)
            {
                _parametersSettingsDatas[i].Id = Convert.ToInt32(dataGridViewVariableParameters[1, i].Value.ToString().Substring(2), 16);
                _parametersSettingsDatas[i].Name = dataGridViewVariableParameters[2, i].Value.ToString();
                _parametersSettingsDatas[i].Type = dataGridViewVariableParameters[3, i].Value.ToString();
                _parametersSettingsDatas[i].Value = dataGridViewVariableParameters[4, i].Value.ToString();
            }
        }

        private void WriteDataToParametersTable(int index, byte subindex, string value)
        {
            dataGridViewVariableParameters[2+subindex, index - startIndex].Value = value;
        }

        private string ReadDataFromParametersTable(int index, int subindex)
        {
            string value;
            value = dataGridViewVariableParameters[subindex + 2, index - startIndex].Value.ToString();
            return value;
        }

        private void OpenFileFunction()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = @"prm files (*.prm)|*.prm";
            string dir = IoC.Resolve<MineConfig>().ParametersConfig.ParametersFileName;
            dir = dir.Substring(0, dir.LastIndexOf('\\'));
            openFileDialog1.InitialDirectory = dir;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IoC.Resolve<MineConfig>().ParametersConfig.ParametersFileName = openFileDialog1.FileName;
                InitData();
            }
        }

        #region Handlers
      
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            AddLineToLog("Открыто окно редактирования параметра с индексом " + "0x" + Convert.ToString(startIndex + _contextMenuClickedRow, 16));
            FormCodtDomainSettings f4 = new FormCodtDomainSettings(startIndex + _contextMenuClickedRow, _parametersSettingsDatas);
            f4.ShowDialog();
            f4.Dispose();
        }

        private void AddRowButton_Click(object sender, EventArgs e)
        {
            FormAddParameterSettings f5 = new FormAddParameterSettings();
            f5.ShowDialog();
            /*variableParametersCount++;
            dataGridViewVariableParameters.RowCount = variableParametersCount;
            dataGridViewVariableParameters[0, dataGridViewVariableParameters.RowCount - 1].Value = dataGridViewVariableParameters.RowCount - 1;
            dataGridViewVariableParameters[1, dataGridViewVariableParameters.RowCount - 1].Value = "0x" + Convert.ToString(startIndex + dataGridViewVariableParameters.RowCount - 1, 16);
            dataGridViewVariableParameters[2, dataGridViewVariableParameters.RowCount - 1].Value = dataGridViewVariableParameters.RowCount - 1;
            dataGridViewVariableParameters[3, dataGridViewVariableParameters.RowCount - 1].Value = " ";
            dataGridViewVariableParameters[4, dataGridViewVariableParameters.RowCount - 1].Value = 0; */
            InitData();
            AddLineToLog("Добавлен новый параметр с индексом " + "0x" + Convert.ToString(startIndex + dataGridViewVariableParameters.RowCount - 1, 16));
            //f5.Closed += F5OnClosed;
            //AddLineToLog("Добавлен новый параметр с индексом " + "0x" + Convert.ToString(startIndex + dataGridViewVariableParameters.RowCount - 1, 16));
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddLineToLog("Загрузка параметра с индексом " + "0x" + Convert.ToString(startIndex + _contextMenuClickedRow, 16));
            LoadParameter(startIndex + _contextMenuClickedRow, _contextMenuClickedColumn - 2);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AddLineToLog("Старт выгрузки параметра с индексом " + "0x" + Convert.ToString(startIndex + _contextMenuClickedRow, 16));
            UnloadParameter(startIndex + _contextMenuClickedRow, _contextMenuClickedColumn - 2);
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

        private void DeleteRowButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить последний параметр?", "Удаление параметра", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                dataGridViewVariableParameters.RowCount = dataGridViewVariableParameters.RowCount - 1;
                InitData();
                AddLineToLog("Удалён параметр с индексом " + "0x" +
                             Convert.ToString(startIndex + dataGridViewVariableParameters.RowCount, 16));
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = @"prm files (*.prm)|*.prm";
            string dir = IoC.Resolve<MineConfig>().ParametersConfig.ParametersFileName;
            dir = dir.Substring(0, dir.LastIndexOf('\\'));
            string name = IoC.Resolve<MineConfig>().ParametersConfig.ParametersFileName;
            name = name.Substring(name.LastIndexOf('\\') + 1, name.Length - name.LastIndexOf('\\') - 1);
            saveFileDialog.FileName = name;
            saveFileDialog.InitialDirectory = dir;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                IoC.Resolve<MineConfig>().ParametersConfig.ParametersFileName = saveFileDialog.FileName;
                SaveParametersData();
                _parametersSettingsVm.WriteToFile(saveFileDialog.FileName, _parametersSettingsDatas);
            }
            AddLineToLog("Текущие названия и значения параметров сохранены ");
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            OpenFileFunction();
        }

        #endregion

        double calculatedWayVeightAndEquipment = 0;
        double calculatedWayPeople = 0;
        double dotWayVeightAndEquipment = 0;
        double dotWayPeople = 0;
        //List<int> _indexes = new List<int>();
        private int _contextMenuClickedRow = 0;
        private int _contextMenuClickedColumn = 0;
        private int startIndex = 0x2001;
        private ParametersSettingsVm _parametersSettingsVm;
        private List<ParametersSettingsData> _parametersSettingsDatas;

    }
}
