using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VisualizationSystem.Services
{
    static class ConfigParameters
    {
        public static double Distance;
        public static double MaxV;
        public static double MaxTokAnchor;//kA
        public static double MaxTokExcitation;//A
        public static double MaxVofDopRule;

        public static void ReadConfigParameters()
        {
            try
            {
                string Line;
                string[] strArr;
                char[] charArr = new char[] { ' ' };
                int k = 0;
                double[] param = new double[5];
                FileStream fs = new FileStream("config_file.txt", FileMode.OpenOrCreate);
                StreamReader sr = new StreamReader(fs, Encoding.UTF8);
                while (sr.EndOfStream != true)
                {
                    Line = sr.ReadLine();
                    strArr = Line.Split(charArr);
                    for (int i = 0; i < strArr.Length; i++)
                    {
                        if (i == 1)
                        {
                            param[k] = Convert.ToDouble(strArr[i].Trim(), CultureInfo.GetCultureInfo("en-US"));
                        }
                    }
                    k++;
                }
                sr.Close();
                Distance = param[0];
                MaxV = param[1];
                MaxTokAnchor = param[2];
                MaxTokExcitation = param[3];
                MaxVofDopRule = param[4];
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
