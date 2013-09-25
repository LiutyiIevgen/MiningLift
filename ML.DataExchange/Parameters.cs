using System;

namespace ML.DataExchange
{
    public class Parameters
    {
        public Parameters(double[] param)
        {
            signal = new int[24];
            set_parameters(param);
            GetSignals();
        }

        private void set_parameters(double[] param)
        {
            s = param[0];
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
        }

        public void GetSignals()
        {
            for (int i = 0; i < 24; i++)
            {
                signal[i] = 0;
            }
        }

        public double s { get; private set; }//текущее значение пути
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
        //
        public double tok_anchor { get; set; } //ток якоря 
        public double tok_excitation { get; set; } //ток возбуждения
        //signals in central part of screen
        public int[] signal { get; private set; }
    }
}
