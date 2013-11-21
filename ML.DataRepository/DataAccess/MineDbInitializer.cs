using System.Collections.Generic;
using System.Data.Entity;
using ML.DataRepository.Models;

namespace ML.DataRepository.DataAccess
{
    public class MineDbInitializer : DropCreateDatabaseIfModelChanges<MineContext>
    {
        protected override void Seed(MineContext context)
        {
            if (context == null)
                context = new MineContext();

            //Init IOsignalType table
            var IOsignalType = new List<IOsignalType>
                {
                    new IOsignalType {Type = "1-X7DI-1"},
                    new IOsignalType {Type = "1-X7DI-2"},
                    new IOsignalType {Type = "1-X7DI-3"},
                    new IOsignalType {Type = "1-X7DI-4"},
                    new IOsignalType {Type = "1-X7DI-5"},
                    new IOsignalType {Type = "1-X7DI-6"},
                    new IOsignalType {Type = "1-X7DI-7"},
                    new IOsignalType {Type = "1-X7DI-8"},
                    new IOsignalType {Type = "2-X7DI-1"},
                    new IOsignalType {Type = "2-X7DI-2"},
                    new IOsignalType {Type = "2-X7DI-3"},
                    new IOsignalType {Type = "2-X7DI-4"},
                    new IOsignalType {Type = "2-X7DI-5"},
                    new IOsignalType {Type = "2-X7DI-6"},
                    new IOsignalType {Type = "2-X7DI-7"},
                    new IOsignalType {Type = "2-X7DI-8"},
                    new IOsignalType {Type = "3-X7DI-1"},
                    new IOsignalType {Type = "3-X7DI-2"},
                    new IOsignalType {Type = "3-X7DI-3"},
                    new IOsignalType {Type = "3-X7DI-4"},
                    new IOsignalType {Type = "3-X7DI-5"},
                    new IOsignalType {Type = "3-X7DI-6"},
                    new IOsignalType {Type = "3-X7DI-7"},
                    new IOsignalType {Type = "3-X7DI-8"},
                    new IOsignalType {Type = "4-X5IN1-1"},
                    new IOsignalType {Type = "4-X5IN1-2"},
                    new IOsignalType {Type = "4-X5IN1-3"},
                    new IOsignalType {Type = "4-X5IN1-4"},
                    new IOsignalType {Type = "4-X5IN1-5"},
                    new IOsignalType {Type = "4-X5IN1-6"},
                    new IOsignalType {Type = "4-X5IN1-7"},
                    new IOsignalType {Type = "4-X5IN1-8"},
                    new IOsignalType {Type = "4-X10IN2-1"},
                    new IOsignalType {Type = "4-X10IN2-2"},
                    new IOsignalType {Type = "4-X10IN2-3"},
                    new IOsignalType {Type = "4-X10IN2-4"},
                    new IOsignalType {Type = "4-X10IN2-5"},
                    new IOsignalType {Type = "4-X10IN2-6"},
                    new IOsignalType {Type = "4-X10IN2-7"},
                    new IOsignalType {Type = "4-X10IN2-8"},
                    new IOsignalType {Type = "4-X15IN3-1"},
                    new IOsignalType {Type = "4-X15IN3-2"},
                    new IOsignalType {Type = "4-X15IN3-3"},
                    new IOsignalType {Type = "4-X15IN3-4"},
                    new IOsignalType {Type = "4-X15IN3-5"},
                    new IOsignalType {Type = "4-X15IN3-6"},
                    new IOsignalType {Type = "4-X15IN3-7"},
                    new IOsignalType {Type = "4-X15IN3-8"},
                    new IOsignalType {Type = "5-X5IN1-1"},
                    new IOsignalType {Type = "5-X5IN1-2"},
                    new IOsignalType {Type = "5-X5IN1-3"},
                    new IOsignalType {Type = "5-X5IN1-4"},
                    new IOsignalType {Type = "5-X5IN1-5"},
                    new IOsignalType {Type = "5-X5IN1-6"},
                    new IOsignalType {Type = "5-X5IN1-7"},
                    new IOsignalType {Type = "5-X5IN1-8"},
                    new IOsignalType {Type = "5-X10IN2-1"},
                    new IOsignalType {Type = "5-X10IN2-2"},
                    new IOsignalType {Type = "5-X10IN2-3"},
                    new IOsignalType {Type = "5-X10IN2-4"},
                    new IOsignalType {Type = "5-X10IN2-5"},
                    new IOsignalType {Type = "5-X10IN2-6"},
                    new IOsignalType {Type = "5-X10IN2-7"},
                    new IOsignalType {Type = "5-X10IN2-8"},
                    new IOsignalType {Type = "5-X15IN3-1"},
                    new IOsignalType {Type = "5-X15IN3-2"},
                    new IOsignalType {Type = "5-X15IN3-3"},
                    new IOsignalType {Type = "5-X15IN3-4"},
                    new IOsignalType {Type = "5-X15IN3-5"},
                    new IOsignalType {Type = "5-X15IN3-6"},
                    new IOsignalType {Type = "5-X15IN3-7"},
                    new IOsignalType {Type = "5-X15IN3-8"},
                    new IOsignalType {Type = "1-X9DO-1"},
                    new IOsignalType {Type = "1-X9DO-2"},
                    new IOsignalType {Type = "1-X9DO-3"},
                    new IOsignalType {Type = "1-X9DO-4"},
                    new IOsignalType {Type = "1-X9DO-5"},
                    new IOsignalType {Type = "1-X9DO-6"},
                    new IOsignalType {Type = "1-X9DO-7"},
                    new IOsignalType {Type = "1-X9DO-8"},
                    new IOsignalType {Type = "2-X9DO-1"},
                    new IOsignalType {Type = "2-X9DO-2"},
                    new IOsignalType {Type = "2-X9DO-3"},
                    new IOsignalType {Type = "2-X9DO-4"},
                    new IOsignalType {Type = "2-X9DO-5"},
                    new IOsignalType {Type = "2-X9DO-6"},
                    new IOsignalType {Type = "2-X9DO-7"},
                    new IOsignalType {Type = "2-X9DO-8"},
                    new IOsignalType {Type = "3-X9DO-1"},
                    new IOsignalType {Type = "3-X9DO-2"},
                    new IOsignalType {Type = "3-X9DO-3"},
                    new IOsignalType {Type = "3-X9DO-4"},
                    new IOsignalType {Type = "3-X9DO-5"},
                    new IOsignalType {Type = "3-X9DO-6"},
                    new IOsignalType {Type = "3-X9DO-7"},
                    new IOsignalType {Type = "3-X9DO-8"},
                    new IOsignalType {Type = "4-X6OUT1-1"},
                    new IOsignalType {Type = "4-X6OUT1-2"},
                    new IOsignalType {Type = "4-X6OUT1-3"},
                    new IOsignalType {Type = "4-X6OUT1-4"},
                    new IOsignalType {Type = "4-X6OUT1-5"},
                    new IOsignalType {Type = "4-X6OUT1-6"},
                    new IOsignalType {Type = "4-X6OUT1-7"},
                    new IOsignalType {Type = "4-X6OUT1-8"},
                    new IOsignalType {Type = "4-X11OUT2-1"},
                    new IOsignalType {Type = "4-X11OUT2-2"},
                    new IOsignalType {Type = "4-X11OUT2-3"},
                    new IOsignalType {Type = "4-X11OUT2-4"},
                    new IOsignalType {Type = "4-X11OUT2-5"},
                    new IOsignalType {Type = "4-X11OUT2-6"},
                    new IOsignalType {Type = "4-X11OUT2-7"},
                    new IOsignalType {Type = "4-X11OUT2-8"},
                    new IOsignalType {Type = "4-X16OUT3-1"},
                    new IOsignalType {Type = "4-X16OUT3-2"},
                    new IOsignalType {Type = "4-X16OUT3-3"},
                    new IOsignalType {Type = "4-X16OUT3-4"},
                    new IOsignalType {Type = "4-X16OUT3-5"},
                    new IOsignalType {Type = "4-X16OUT3-6"},
                    new IOsignalType {Type = "4-X16OUT3-7"},
                    new IOsignalType {Type = "4-X16OUT3-8"},
                    new IOsignalType {Type = "5-X6OUT1-1"},
                    new IOsignalType {Type = "5-X6OUT1-2"},
                    new IOsignalType {Type = "5-X6OUT1-3"},
                    new IOsignalType {Type = "5-X6OUT1-4"},
                    new IOsignalType {Type = "5-X6OUT1-5"},
                    new IOsignalType {Type = "5-X6OUT1-6"},
                    new IOsignalType {Type = "5-X6OUT1-7"},
                    new IOsignalType {Type = "5-X6OUT1-8"},
                    new IOsignalType {Type = "5-X11OUT2-1"},
                    new IOsignalType {Type = "5-X11OUT2-2"},
                    new IOsignalType {Type = "5-X11OUT2-3"},
                    new IOsignalType {Type = "5-X11OUT2-4"},
                    new IOsignalType {Type = "5-X11OUT2-5"},
                    new IOsignalType {Type = "5-X11OUT2-6"},
                    new IOsignalType {Type = "5-X11OUT2-7"},
                    new IOsignalType {Type = "5-X11OUT2-8"},
                    new IOsignalType {Type = "5-X16OUT3-1"},
                    new IOsignalType {Type = "5-X16OUT3-2"},
                    new IOsignalType {Type = "5-X16OUT3-3"},
                    new IOsignalType {Type = "5-X16OUT3-4"},
                    new IOsignalType {Type = "5-X16OUT3-5"},
                    new IOsignalType {Type = "5-X16OUT3-6"},
                    new IOsignalType {Type = "5-X16OUT3-7"},
                    new IOsignalType {Type = "5-X16OUT3-8"}
                };
            IOsignalType.ForEach(d => context.IOsignalType.Add(d));

            //Init IOsignalState table
            var IOsignalState = new List<IOsignalState>
                {
                    new IOsignalState {State = "лог 0"},
                    new IOsignalState {State = "лог 1"},
                    new IOsignalState {State = "нет данных"}
                };
            IOsignalState.ForEach(d => context.IOsignalState.Add(d));

            //Init MainDigitSignalType table
            var MainDigitSignalType = new List<MainDigitSignalType>
                {
                    new MainDigitSignalType {Type = "ТП взведён"},
                    new MainDigitSignalType {Type = "Переподъём ФПК Н"},
                    new MainDigitSignalType {Type = "Переподъём ДКПУ Н"},
                    new MainDigitSignalType {Type = "Износ колодок"},
                    new MainDigitSignalType {Type = "Переподъём ФПК В"},
                    new MainDigitSignalType {Type = "Переподъём ДКПУ В"},
                    new MainDigitSignalType {Type = "ВВ включён"},
                    new MainDigitSignalType {Type = "ВАТ включён"},
                    new MainDigitSignalType {Type = "Контроль ОСЭРП"},
                    new MainDigitSignalType {Type = "Превышение скорости ОСЭРП"},
                    new MainDigitSignalType {Type = "Контроль растормаж машины"},
                    new MainDigitSignalType {Type = "Превышение скорости ФПК и ОС"},
                    new MainDigitSignalType {Type = "Обратныйход"},
                    new MainDigitSignalType {Type = "Контроль выбора схемы"},
                    new MainDigitSignalType {Type = "Контроль выбора режима"},
                    new MainDigitSignalType {Type = "Контроль АШСС и С"},
                    new MainDigitSignalType {Type = "Контроль затормаж машины"},
                    new MainDigitSignalType {Type = "Контроль" + @"""0""" + "СКАР"},
                    new MainDigitSignalType {Type = "Контроль" + @"""0""" + "ВБТР"},
                    new MainDigitSignalType {Type = "Контроль кнопки взвода ТП"},
                    new MainDigitSignalType {Type = "Готовность преобраз-ля"},
                    new MainDigitSignalType {Type = "ТР взведен"},
                    new MainDigitSignalType {Type = "Контроль давления ТП"},
                    new MainDigitSignalType {Type = "Запрет пуска"},

                };
            MainDigitSignalType.ForEach(d => context.MainDigitSignalType.Add(d));

            //Init IOsignalState table
            var MainDigitSignalState = new List<MainDigitSignalState>
                {
                    new MainDigitSignalState {State = "норма"},
                    new MainDigitSignalState {State = "авария"}
                };
            MainDigitSignalState.ForEach(d => context.MainDigitSignalState.Add(d));

            //Init FanState table
           /* var fanState = new List<FanState>
                {
                    new FanState {State = "Выключен"},
                    new FanState {State = "Включен"},
                };
            fanState.ForEach(d => context.FanState.Add(d)); */

            //Init AnalogSignalType table
            var analogSignalType = new List<AnalogSignal>
                {
                    new AnalogSignal {Type = "Путь (м)"},
                    new AnalogSignal {Type = "Скорость (м/с)"},
                    new AnalogSignal {Type = "Ток якоря (кА)"},
                    new AnalogSignal {Type = "Ток возбуждения (А)"}
                };
            analogSignalType.ForEach(s => context.AnalogSignals.Add(s));

            //Init Settings дублирование настроек в базу для веб сервера mvc
            var settings = new List<SettingsLog>
            {
                new SettingsLog {Name = "MaxTemperature", DValue = 120},
                new SettingsLog {Name = "MaxPillowValue", DValue = 35},
                new SettingsLog {Name = "MaxAirFlowValue", DValue = 80},
                new SettingsLog {Name = "MaxPressureValue", DValue = 6},
                new SettingsLog {Name = "MaxSpeedValue", DValue = 300},
                new SettingsLog {Name = "MaxCurrentValue", DValue = 300},
                new SettingsLog {Name = "MaxOilFlowValue", DValue = 10},
                new SettingsLog {Name = "MaxSignalQualityValue", DValue = 32},
                new SettingsLog {Name = "TemperatureСoefficient", DValue = 1.2},
                new SettingsLog {Name = "PillowСoefficient", DValue = 1},
                new SettingsLog {Name = "AirFlowСoefficient", DValue = 1.97},
                new SettingsLog {Name = "PressureСoefficient", DValue = 0.1},
                new SettingsLog {Name = "RemotePassword", SValue = "2243"},
                new SettingsLog {Name = "FanObjectCount", DValue = 2},
                new SettingsLog {Name = "mineName", SValue = "Название шахты"},
                new SettingsLog {Name = "fansName", SValue = "Один!$!Два"},
                new SettingsLog {Name = "generalAnalogSignalsView", SValue = "0!$!1!$!2!$!3!$!4!$!5!$!6"},
                new SettingsLog
                {
                    Name = "pressure",
                    Warning = 1,
                    Danger = 0.5
                },
                new SettingsLog
                {
                    Name = "airConsumption",
                    Warning = 40,
                    Danger = 30
                },
                new SettingsLog
                {
                    Name = "pillowTemperature",
                    Warning = 60,
                    Danger = 80
                },
                new SettingsLog
                {
                    Name = "pillowVibration",
                    Warning = 20,
                    Danger = 30
                },
                new SettingsLog
                {
                    Name = "statorCurrent",
                    Warning = 100,
                    Danger = 150
                },
                new SettingsLog
                {
                    Name = "rotorCurrentLow",
                    Warning = 200,
                    Danger = 180
                },
                new SettingsLog
                {
                    Name = "rotorCurrentHigh",
                    Warning = 280,
                    Danger = 290
                },
                new SettingsLog
                {
                    Name = "oilFlow",
                    Warning = 6,
                    Danger = 2
                },
                new SettingsLog
                {
                    Name = "gprsQuality",
                    Warning = 21,
                    Danger = 17
                }

            };
            settings.ForEach(s => context.SettingsLog.Add(s));

            var remoteState = new List<RemoteState>
                {
                    new RemoteState {State = "Включить вентилятор №1"},
                    new RemoteState {State = "Включить вентилятор №2"},
                    new RemoteState {State = "Выключить"}
                };
            remoteState.ForEach(s => context.RemoteState.Add(s));

            context.SaveChanges();
        }
    }
}
