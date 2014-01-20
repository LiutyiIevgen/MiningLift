using System;
using System.Collections.Generic;

namespace ML.DataExchange.Model
{
    public class Parameters
    {
        public Parameters()
        {
            
        }
        public Parameters(double[] param)
        {
            signal = new int[24];
            AuziDIOSignalsState = new List<AuziDState>();
            set_parameters(param);
            GetSignals();
            SetAuziDIOSignalsState();
            DefenceDiagramRegime = 1;//"груз"
        }

        private void set_parameters(double[] param)
        {
            s = -param[0];
            v = param[1];
            a = param[2];
            f_slowdown_zone = Convert.ToInt32(param[3]);
            f_dot_zone = Convert.ToInt32(param[4]);
            f_start = Convert.ToInt32(param[5]);
            f_slowdown_zone_back = Convert.ToInt32(param[6]);
            f_dot_zone_back = Convert.ToInt32(param[7]);
            f_back = Convert.ToInt32(param[8]);
            f_ostanov = Convert.ToInt32(param[9]);
            unload_state = Convert.ToInt32(param[10]);
            load_state = Convert.ToInt32(param[11]);
            s_two = -param[12];
        }

        public void GetSignals()
        {
            for (int i = 0; i < 24; i++)
            {
                signal[i] = 0;
            }
            //signal[11] = 1;
        }

        private void SetAuziDIOSignalsState()
        {
            for (int i = 0; i < 144; i++)
            {
                AuziDIOSignalsState.Add(AuziDState.Undefind);
            }
            AuziDIByteList = new List<byte>();
            AuziDOByteList = new List<byte>();
            for (int i = 0; i < 9; i++)
            {
                AuziDIByteList.Add(new byte());
                AuziDOByteList.Add(new byte());
            }
        }

        public void SetAuziDOSignalsState(List<byte> byteList)
        {
            AuziDOByteList = byteList;
            var signals = new List<AuziDState>();
            foreach (var _byte in byteList)
            {
                byte b = _byte;
                for (int i = 0; i < 8; i++)
                {
                    signals.Add((b & 0x01) == 1 ? AuziDState.Off : AuziDState.On);
                    b = (byte)(b >> 1);
                }
            }
            for (int i = 0; i < signals.Count && i < 72; i++)
            {
                AuziDIOSignalsState[i + 72] = signals[i];
            }
        }

        public void SetAuziDISignalsState(List<byte> byteList)
        {
            AuziDIByteList = byteList;
            var signals = new List<AuziDState>();
            foreach (var _byte in byteList)
            {
                byte b = _byte;
                for (int i = 0; i < 8; i++)
                {
                    signals.Add((b & 0x01) == 1 ? AuziDState.Off : AuziDState.On);
                    b = (byte)(b >> 1);
                }
            }
            for (int i = 0; i < signals.Count && i < 72; i++)
            {
                AuziDIOSignalsState[i] = signals[i];
            }
        }

        public double s { get; private set; }//текущее значение пути клеть 1
        public double v { get; private set; }//текущее значение скорости
        public double a { get; private set; } //текущее значение ускорения
        public int f_slowdown_zone { get; private set; } //флаг зоны замедления
        public int f_dot_zone { get; private set; }// флаг зоны дотяжки
        public int f_start { get; private set; }
        public int f_slowdown_zone_back { get; private set; } //флаг зоны замедления
        public int f_dot_zone_back { get; private set; }// флаг зоны дотяжки
        public int f_back { get; private set; }
        public int f_ostanov { get; private set; }
        public int unload_state { get; private set; }
        public int load_state { get; private set; }
        public double s_two { get; private set; }//текущее значение пути клеть 2
        //
        public double tok_anchor { get; set; } //ток якоря 
        public double tok_excitation { get; set; } //ток возбуждения
        //signals in central part of screen
        public int[] signal { get; private set; }
        // AUZI-D iput and output signals
        public List<AuziDState> AuziDIOSignalsState { get; private set; }
        public List<byte> AuziDIByteList { get; private set; }
        public List<byte> AuziDOByteList { get; private set; }
        //номер режима защитной диаграммы
        public int DefenceDiagramRegime { get; private set; }
    }
}
