﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using ML.DataExchange;
using VisualizationSystem.Model.RichTextBoxData;

namespace VisualizationSystem.ViewModel
{
    class CentralSignalsDataVm
    {
        public CentralSignalsDataVm(Parameters parameter)
        {
            _parameters = parameter;
            SignalsData = new RichTextBoxData[24];
            for (int i = 0; i < 24;i++ )
                SignalsData[i] = new RichTextBoxData();
            positiv_signals = new string[24];//названия положительных сигналов центральной части экрана
            negativ_signals = new string[24];//названия отрицательных сигналов центральной части экрана

            SetPositiveNegativeSignalsNames();
            SolveSignalsData();
        }

        private void SetPositiveNegativeSignalsNames()
        {
            positiv_signals[0] = "ТП\r\nвзведён";
            positiv_signals[1] = "Переподъём\r\nФПК Н";
            positiv_signals[2] = "Переподъём\r\nДКПУ Н";
            positiv_signals[3] = "Износ\r\nколодок";
            positiv_signals[4] = "Переподъём\r\nФПК В";
            positiv_signals[5] = "Переподъём\r\nДКПУ В";
            positiv_signals[6] = "ВВ\r\nвключён";
            positiv_signals[7] = "ВАТ\r\nвключён";
            positiv_signals[8] = "Контроль\r\nОСЭРП";
            positiv_signals[9] = "Превышение\r\nскорости\r\nОСЭРП";
            positiv_signals[10] = "Контроль\r\nрастормаж\r\nмашины";
            positiv_signals[11] = "Превышение\r\nскорости\r\nФПК и ОС";
            positiv_signals[12] = "Обратный\r\nход";
            positiv_signals[13] = "Контроль\r\nвыбора\r\nсхемы";
            positiv_signals[14] = "Контроль\r\nвыбора\r\nрежима";
            positiv_signals[15] = "Контроль\r\nАШСС и С";
            positiv_signals[16] = "Контроль\r\nзатормаж\r\nмашины";
            positiv_signals[17] = "Контроль\r\n" + @"""0""" + "СКАР";
            positiv_signals[18] = "Контроль\r\n" + @"""0""" + "ВБТР";
            positiv_signals[19] = "Контроль\r\nкнопки\r\nвзвода ТП";
            positiv_signals[20] = "Готовность\r\nпреобраз-ля";
            positiv_signals[21] = "ТР\r\nвзведен";
            positiv_signals[22] = "Контроль\r\nдавления ТП";
            positiv_signals[23] = "Запрет\r\nпуска";
            negativ_signals[0] = "ТП\r\nвзведён";
            negativ_signals[1] = "Переподъём\r\nФПК Н";
            negativ_signals[2] = "Переподъём\r\nДКПУ Н";
            negativ_signals[3] = "Износ\r\nколодок";
            negativ_signals[4] = "Переподъём\r\nФПК В";
            negativ_signals[5] = "Переподъём\r\nДКПУ В";
            negativ_signals[6] = "ВВ\r\nвключён";
            negativ_signals[7] = "ВАТ\r\nвключён";
            negativ_signals[8] = "Контроль\r\nОСЭРП";
            negativ_signals[9] = "Превышение\r\nскорости\r\nОСЭРП";
            negativ_signals[10] = "Контроль\r\nрастормаж\r\nмашины";
            negativ_signals[11] = "Превышение\r\nскорости\r\nФПК и ОС";
            negativ_signals[12] = "Обратный\r\nход";
            negativ_signals[13] = "Контроль\r\nвыбора\r\nсхемы";
            negativ_signals[14] = "Контроль\r\nвыбора\r\nрежима";
            negativ_signals[15] = "Контроль\r\nАШСС и С";
            negativ_signals[16] = "Контроль\r\nзатормаж\r\nмашины";
            negativ_signals[17] = "Контроль\r\n" + @"""0""" + "СКАР";
            negativ_signals[18] = "Контроль\r\n" + @"""0""" + "ВБТР";
            negativ_signals[19] = "Контроль\r\nкнопки\r\nвзвода ТП";
            negativ_signals[20] = "Готовность\r\nпреобраз-ля";
            negativ_signals[21] = "ТР\r\nвзведен";
            negativ_signals[22] = "Контроль\r\nдавления ТП";
            negativ_signals[23] = "Запрет\r\nпуска";
        }

        private void SolveSignalsData()
        {
            for (int i = 0; i < 24; i++)
            {
                if (_parameters.signal[i] == 0)
                {
                    SignalsData[i].BackColor = Color.DarkGray;
                    SignalsData[i].Text = positiv_signals[i];
                }
                else
                {
                    SignalsData[i].BackColor = Color.Red;
                    SignalsData[i].Text = negativ_signals[i];
                }
            }
        }

        public RichTextBoxData[] SignalsData { get; private set; }
        private Parameters _parameters;
        string[] positiv_signals;//названия положительных сигналов центральной части экрана
        string[] negativ_signals;//названия отрицательных сигналов центральной части экрана
    }
}