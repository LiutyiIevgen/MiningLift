using System.Drawing;
using ML.ConfigSettings.Model;
using ML.ConfigSettings.Services;
using ML.DataExchange.Model;
using VisualizationSystem.Model;
using VisualizationSystem.Model.RichTextBoxData;

namespace VisualizationSystem.ViewModel.MainViewModel
{
    class LoadDataVm
    {
        public LoadDataVm(Parameters parameter)
        {
            _parameters = parameter;
            LoadData = new RichTextBoxData[4];
            for (int i = 0; i < 4;i++ )
                LoadData[i] = new RichTextBoxData();
            SolveLoadData();
        }

        private void SolveLoadData()
        {
            Color[] colors = { Color.Red, Color.Red, Color.Red, Color.Green, Color.Gray };
            string[] textFirst = { "ЗАТВОР \r\nОТКРЫТ", "СКИП \r\nРАЗГРУЖАЕТСЯ", "СКИП \r\nРАЗГРУЗИЛСЯ", "ЗАТВОР \r\nЗАКРЫТ", "" };
            string[] textSecod = { "ДОЗАТОР \r\nОТКРЫТ", "СКИП \r\nЗАГРУЖАЕТСЯ", "СКИП \r\nЗАГРУЖЕН", "ДОЗАТОР \r\nЗАКРЫТ", "" };

            // сообщения разгрузки (вверху)
            if (_parameters.f_ostanov == 1 && _parameters.s < (IoC.Resolve<MineConfig>().MainViewConfig.BorderZero.Value + 0.5) && _parameters.s > (IoC.Resolve<MineConfig>().MainViewConfig.BorderZero.Value - 0.5))
            {
                for (int i = 1; i <= 5; i++)
                {
                    if (_parameters.unload_state == i)
                    {
                        int i1 = i - 1;
                        if (IoC.Resolve<MineConfig>().MainViewConfig.LeftSosud == SosudType.Skip)
                        {
                            LoadData[0].BackColor = colors[i1];
                            LoadData[0].Text = textFirst[i1];
                        }
                        if (IoC.Resolve<MineConfig>().MainViewConfig.RightSosud == SosudType.Skip && RightPanelVm._firstTime == 1)
                        {
                            LoadData[3].BackColor = colors[i1];
                            LoadData[3].Text = textSecod[i1];
                        }
                    }
                }
            }
            else
            {
                if (IoC.Resolve<MineConfig>().MainViewConfig.LeftSosud == SosudType.Skip)
                {
                    LoadData[0].BackColor = Color.Gray;
                    LoadData[0].Text = "";
                }
                if (IoC.Resolve<MineConfig>().MainViewConfig.RightSosud == SosudType.Skip && RightPanelVm._firstTime == 1)
                {
                    LoadData[3].BackColor = Color.Gray;
                    LoadData[3].Text = "";
                }
            }
            // сообщения загрузки (внизу)
            if (_parameters.f_ostanov == 1 && _parameters.s > (IoC.Resolve<MineConfig>().MainViewConfig.Border.Value - 0.5) && _parameters.s < (IoC.Resolve<MineConfig>().MainViewConfig.Border.Value + 0.5))
            {
                for (int i = 1; i <= 5; i++)
                {
                    if (_parameters.load_state == i)
                    {
                        int i1 = i - 1;
                        if (IoC.Resolve<MineConfig>().MainViewConfig.LeftSosud == SosudType.Skip)
                        {
                            LoadData[1].BackColor = colors[i1];
                            LoadData[1].Text = textSecod[i1];
                        }
                        if (IoC.Resolve<MineConfig>().MainViewConfig.RightSosud == SosudType.Skip && RightPanelVm._firstTime == 1)
                        {
                            LoadData[2].BackColor = colors[i1];
                            LoadData[2].Text = textFirst[i1];
                        }
                    }
                }
            }
            else
            {
                if (IoC.Resolve<MineConfig>().MainViewConfig.LeftSosud == SosudType.Skip)
                {
                    LoadData[1].BackColor = Color.Gray;
                    LoadData[1].Text = "";
                }
                if (IoC.Resolve<MineConfig>().MainViewConfig.RightSosud == SosudType.Skip && RightPanelVm._firstTime == 1)
                {
                    LoadData[2].BackColor = Color.Gray;
                    LoadData[2].Text = "";
                }
            }
        }

        public RichTextBoxData[] GetLoadData()
        {
            return LoadData;
        }

        public RichTextBoxData[] LoadData { get; private set; }
        private Parameters _parameters;
    }
}
