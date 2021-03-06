﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
            _mineConfig = IoC.Resolve<MineConfig>();
            _deviceInformation = new List<string>();
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
                _parametersSettingsVm.ReadFromFile(_mineConfig.ParametersConfig.ParametersFileName);
                RefreshGrid();
            }
            catch (Exception)
            {
                OpenFileFunction();
            }
            
            // CalculateParameters();
        }

        private void RefreshGrid()
        {
            dataGridViewVariableParameters.RowCount = _parametersSettingsVm.ParametersSettingsDatas.Count;
            for (int i = 0; i < dataGridViewVariableParameters.RowCount; i++)
            {
                dataGridViewVariableParameters[0, i].Value = i;
                dataGridViewVariableParameters[1, i].Value = "0x" + Convert.ToString(_parametersSettingsVm.ParametersSettingsDatas[i].Id, 16);
                dataGridViewVariableParameters[2, i].Value = _parametersSettingsVm.ParametersSettingsDatas[i].Name;
                dataGridViewVariableParameters[3, i].Value = _parametersSettingsVm.ParametersSettingsDatas[i].Type;
                dataGridViewVariableParameters[4, i].Value = _parametersSettingsVm.ParametersSettingsDatas[i].Value;
            }
        }

        private void LoadParameter(ushort? controllerId, int index, int subindex) //загрузка
        {
            if (controllerId == null) //get Id from user
            {
                var dialog = new FormCanId { StartPosition = FormStartPosition.CenterScreen };
                dialog.ShowDialog();
                ushort id;
                ushort.TryParse(dialog.textBoxAddress.Text, out id);
                controllerId = id;
            }
            List<byte> data=new List<byte>();
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
                        data.AddRange(BitConverter.GetBytes(f));
                    }
                    else if (ReadDataFromParametersTable(index, 1) == "codtSInt24")
                    {
                        string ssh = ReadDataFromParametersTable(index, subindex);
                        int sh = int.Parse(ssh);
                        var listData = BitConverter.GetBytes(sh).ToList();
                        listData.RemoveAt(listData.Count - 1);
                        data.AddRange(listData.ToArray());
                    }
                    else if (ReadDataFromParametersTable(index, 1) == "codtSInt16")
                    {
                        string ssh = ReadDataFromParametersTable(index, subindex);
                        short sh = short.Parse(ssh);
                        data.AddRange(BitConverter.GetBytes(sh));
                    }
                    else if (ReadDataFromParametersTable(index, 1) == "codtDomain")
                    {
                        var codtDomainArray = _parametersSettingsVm.ParametersSettingsDatas[index - startIndex].CodtDomainArray;
                        for (int i = 0; i < codtDomainArray.Count(); i++)
                        {
                            string firstParamStr = codtDomainArray[i].Coordinate.ToString();
                            int firstParam = int.Parse(firstParamStr);
                            byte[] firstBytes = BitConverter.GetBytes(firstParam);
                            data.AddRange(firstBytes);

                            string secondParamStr = codtDomainArray[i].Speed.ToString();
                            short secondParam = short.Parse(secondParamStr);
                            byte[] secondBytes = BitConverter.GetBytes(secondParam);
                            data.AddRange(secondBytes);
                        }
                    }
                    IoC.Resolve<DataListener>().SetParameter((ushort)controllerId, (ushort)index, (byte)subindex, data.ToArray());
                }               
            }
            catch (Exception)
            {
                
            }
        }

        private void UnloadParameter(ushort? controllerId, int index,int subindex)//выгрузка
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
            if (controllerId == null) //get Id from user
            {
                var dialog = new FormCanId {StartPosition = FormStartPosition.CenterScreen};
                dialog.ShowDialog();
                ushort id;
                ushort.TryParse(dialog.textBoxAddress.Text, out id);
                controllerId = id;
            }
            IoC.Resolve<DataListener>().GetParameter((ushort)controllerId, (ushort)index, (byte)subindex);
        }

        private void UnloadAllParameters()
        {
            var dialog = new FormCanId { StartPosition = FormStartPosition.CenterScreen };
            dialog.ShowDialog();
            ushort controllerId;
            ushort.TryParse(dialog.textBoxAddress.Text, out controllerId);
            int i = 0;
            if (_parametersSettingsVm.ParametersSettingsDatas != null)
                _parametersSettingsVm.ParametersSettingsDatas.Clear();
            else
                _parametersSettingsVm.ParametersSettingsDatas = new List<ParametersSettingsData>();
            int index = startIndex;
            UnloadParameter(controllerId, 0x2000, 1); //read number of parameters
            _isUnloaded.WaitOne();
            while (i < _parametersNumber - 1)
            {
                _parametersSettingsVm.ParametersSettingsDatas.Add(new ParametersSettingsData());
                for (int j = 0; j < 3; j++)
                {
                    Thread.Sleep(30);
                    UnloadParameter(controllerId, index, j);
                    _isUnloaded.WaitOne();
                }
                index++;
                i++;
            }
        }

        private void LoadAllParameters()
        {
            var dialog = new FormCanId { StartPosition = FormStartPosition.CenterScreen };
            dialog.ShowDialog();
            ushort controllerId;
            ushort.TryParse(dialog.textBoxAddress.Text, out controllerId);
            int i = 0;
            int index = startIndex;
            while (i < 88)
            {
                Thread.Sleep(50);
                LoadParameter(controllerId, index, 2);
                _isLoaded.WaitOne();
                index++;
                i++;
            }
        }

        private void UnloadDeviceInformation()
        {
            var dialog = new FormCanId { StartPosition = FormStartPosition.CenterScreen };
            dialog.ShowDialog();
            ushort controllerId;
            ushort.TryParse(dialog.textBoxAddress.Text, out controllerId);
            _deviceInformation.Clear();
            for (int j = 1; j < 7; j++)
            {
                UnloadParameter(controllerId, 0x2000, j);
                _isUnloaded.WaitOne();
            }
            var formDomain = new FormHardwareInformation(_deviceInformation);
            formDomain.ShowDialog();
        }

        private void ParameterReceive(List<CanParameter> parametersList)
        {
            int i =0;
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
                    _isLoaded.Set();
                    continue;
                }
                if (canParameter.ParameterId == 0x2000)
                {
                    DeviceInformationParser(canParameter);
                    _isUnloaded.Set();
                    return;
                }
                switch (canParameter.ParameterSubIndex)
                {
                    case (byte)CanSubindexes.Value:
                        ValueParser(canParameter);
                        _isUnloaded.Set();
                        break;
                    case (byte)CanSubindexes.Name:
                        NamePareser(canParameter);
                        _isUnloaded.Set();
                        break;
                    case (byte)CanSubindexes.Type:
                        TypeParser(canParameter);
                        _isUnloaded.Set();
                        break;
                }
                
                
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
                    int i = 0;
                    var codtDomainDatas = new CodtDomainData[20];
                    while (i < 20)
                    {  
                        codtDomainDatas[i] = new CodtDomainData()
                        {
                            Coordinate = BitConverter.ToInt32(canParameter.Data, i * 6),
                            Speed = BitConverter.ToInt16(canParameter.Data, i * 6 + 4)
                        };
                        i++;
                    }
                    _parametersSettingsVm.ParametersSettingsDatas[canParameter.ParameterId - startIndex].CodtDomainArray = codtDomainDatas;
                    this.Invoke((MethodInvoker)delegate
                    {
                        WriteDataToParametersTable(canParameter.ParameterId, 2, "Двоичные данные");
                        var formDomain = new FormCodtDomainSettings(canParameter.ParameterId, _parametersSettingsVm.ParametersSettingsDatas);
                        formDomain.Show();
                    });  
                }
            this.Invoke((MethodInvoker)delegate
            {
                AddLineToLog("Выгружено значение параметра с индексом " + "0x" +
                    Convert.ToString(canParameter.ParameterId, 16) + ", address = " +
                    Convert.ToString(canParameter.ControllerId, 16));
            });
        }

        private void NamePareser(CanParameter canParameter)
        {
            Encoding ansiCyrillic = Encoding.GetEncoding(1251);
            string name = ansiCyrillic.GetString(canParameter.Data, 0, canParameter.Data.Count());
            WriteDataToParametersTable(canParameter.ParameterId, 0, name);
            this.Invoke((MethodInvoker)delegate
            {
                AddLineToLog("Выгружено имя параметра с индексом " + "0x" +
                    Convert.ToString(canParameter.ParameterId, 16) + ", address = " +
                    Convert.ToString(canParameter.ControllerId, 16));
            });
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
                case 6:
                    WriteDataToParametersTable(canParameter.ParameterId, 1, "codtSInt16");
                    break;
            }
            this.Invoke((MethodInvoker)delegate
            {
                AddLineToLog("Выгружен тип параметра с индексом " + "0x" +
                    Convert.ToString(canParameter.ParameterId, 16) + ", address = " +
                    Convert.ToString(canParameter.ControllerId, 16));
            });
        }

        private void DeviceInformationParser(CanParameter canParameter)
        {
            if (canParameter.ParameterSubIndex == 1) //number of parameters
            {
                short myShort;
                myShort = BitConverter.ToInt16(canParameter.Data, 0);
                _deviceInformation.Add(myShort.ToString());
                _parametersNumber = myShort;
            }
            else // other string information
            {
                Encoding ansiCyrillic = Encoding.GetEncoding(1251);
                string name = ansiCyrillic.GetString(canParameter.Data, 0, canParameter.Data.Count());
                _deviceInformation.Add(name);
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
                _parametersSettingsVm.ParametersSettingsDatas[i].Id = Convert.ToInt32(dataGridViewVariableParameters[1, i].Value.ToString().Substring(2), 16);
                _parametersSettingsVm.ParametersSettingsDatas[i].Name = dataGridViewVariableParameters[2, i].Value.ToString();
                _parametersSettingsVm.ParametersSettingsDatas[i].Type = dataGridViewVariableParameters[3, i].Value.ToString();
                _parametersSettingsVm.ParametersSettingsDatas[i].Value = dataGridViewVariableParameters[4, i].Value.ToString();
            }
        }

        private void WriteDataToParametersTable(int index, byte subindex, string value)
        {
            this.Invoke((MethodInvoker) delegate
            {
                if ((index - startIndex) == dataGridViewVariableParameters.RowCount)
                {
                    dataGridViewVariableParameters.RowCount = dataGridViewVariableParameters.RowCount + 1;
                    dataGridViewVariableParameters[0, index - startIndex].Value = Convert.ToString(index - startIndex);
                    dataGridViewVariableParameters[1, index - startIndex].Value = "0x" + Convert.ToString(index, 16);
                    dataGridViewVariableParameters[2, index - startIndex].Value = "";
                    dataGridViewVariableParameters[3, index - startIndex].Value = "";
                    dataGridViewVariableParameters[4, index - startIndex].Value = "";

                }
                dataGridViewVariableParameters[2 + subindex, index - startIndex].Value = value;
            });
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
            string dir = _mineConfig.ParametersConfig.ParametersFileName;
            dir = dir.Substring(0, dir.LastIndexOf('\\'));
            openFileDialog1.InitialDirectory = dir;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _mineConfig.ParametersConfig.ParametersFileName = openFileDialog1.FileName;
                InitData();
            }
        }

        #region Handlers
      
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            AddLineToLog("Открыто окно редактирования параметра с индексом " + "0x" + Convert.ToString(startIndex + _contextMenuClickedRow, 16));
            FormCodtDomainSettings f4 = new FormCodtDomainSettings(startIndex + _contextMenuClickedRow, _parametersSettingsVm.ParametersSettingsDatas);
            f4.ShowDialog();
            f4.Dispose();
        }

        private void AddRowButton_Click(object sender, EventArgs e)
        {
            FormAddParameterSettings f5 = new FormAddParameterSettings(_parametersSettingsVm.ParametersSettingsDatas);
            f5.ShowDialog();
            RefreshGrid();
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddLineToLog("Загрузка параметра с индексом " + "0x" + Convert.ToString(startIndex + _contextMenuClickedRow, 16));
            LoadParameter(null,startIndex + _contextMenuClickedRow, _contextMenuClickedColumn - 2);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AddLineToLog("Старт выгрузки параметра с индексом " + "0x" + Convert.ToString(startIndex + _contextMenuClickedRow, 16));
            UnloadParameter(null,startIndex + _contextMenuClickedRow, _contextMenuClickedColumn - 2);
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
                _parametersSettingsVm.ParametersSettingsDatas.RemoveAt(_parametersSettingsVm.ParametersSettingsDatas.Count - 1);
                RefreshGrid();
                AddLineToLog("Удалён параметр с индексом " + "0x" +
                             Convert.ToString(startIndex + dataGridViewVariableParameters.RowCount, 16));
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = @"prm files (*.prm)|*.prm";
            string dir = _mineConfig.ParametersConfig.ParametersFileName;
            dir = dir.Substring(0, dir.LastIndexOf('\\'));
            string name = _mineConfig.ParametersConfig.ParametersFileName;
            name = name.Substring(name.LastIndexOf('\\') + 1, name.Length - name.LastIndexOf('\\') - 1);
            saveFileDialog.FileName = name;
            saveFileDialog.InitialDirectory = dir;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _mineConfig.ParametersConfig.ParametersFileName = saveFileDialog.FileName;
                SaveParametersData();
                _parametersSettingsVm.WriteToFile(saveFileDialog.FileName);
            }
            AddLineToLog("Текущие названия и значения параметров сохранены ");
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            OpenFileFunction();
        }

        private void unloadAll_Click(object sender, EventArgs e)
        {
            Thread unloadThread = new Thread(UnloadAllParameters) { IsBackground = true };
            unloadThread.Start();
        }

        private void loadAll_Click(object sender, EventArgs e)
        {
            Thread loadThread = new Thread(LoadAllParameters) { IsBackground = true, Priority = ThreadPriority.Lowest};
            loadThread.Start();
        }

        private void getInformationButton_Click(object sender, EventArgs e)
        {
            Thread loadThread = new Thread(UnloadDeviceInformation) { IsBackground = true };
            loadThread.Start();
        }

        #endregion

        private ParametersSettingsVm _parametersSettingsVm;
        private MineConfig _mineConfig;

        double calculatedWayVeightAndEquipment = 0;
        double calculatedWayPeople = 0;
        double dotWayVeightAndEquipment = 0;
        double dotWayPeople = 0;
        private int _contextMenuClickedRow = 0;
        private int _contextMenuClickedColumn = 0;
        private int startIndex = 0x2001;
        
        private List<string> _deviceInformation;
        EventWaitHandle _isUnloaded = new AutoResetEvent(false);
        EventWaitHandle _isLoaded = new AutoResetEvent(false);
        private int _parametersNumber = 0;

        




    }
}
