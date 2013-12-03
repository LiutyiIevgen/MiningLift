using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ML.DataExchange.CanDriver;

namespace ML.DataExchange
{
    static class CanParser
    {
        public static double GetS(List<AdvCan.canmsg_t> msgData)
        {
            double s = 0;
            byte[] tpdo1 = msgData.FirstOrDefault(p => p.id == 0x181).data;
            s = (tpdo1[3] << 8) + (tpdo1[4] << 16) + (tpdo1[5] << 24);
            s /= 256 * 1000;
            return -s;
        }
        public static double GetV(List<AdvCan.canmsg_t> msgData)
        {
            double v = 0;
            short sv = 0;
            byte[] tpdo2 = msgData.FirstOrDefault(p => p.id == 0x281).data;
            sv = (short)((tpdo2[2]) + (tpdo2[3] << 8));
            v = sv;
            return v/1000;
        }
        public static double GetA(List<AdvCan.canmsg_t> msgData)
        {
            double a = 0;
            short sa = 0;
            byte[] tpdo2 = msgData.FirstOrDefault(p => p.id == 0x281).data;
            sa = (short)((tpdo2[6]) + (tpdo2[7] << 8));
            a = sa;
            return a / 1000;
        }
        public static double GetStart(double v)
        {
            if (v < 0)
                return 1;
            return 0;
        }
        public static double GetBack(double v)
        {
            if (v >= 0)
                return 1;
            return 0;
        }
        public static double GetOstanov(double v)
        {
            /*byte[] tpdo3 = msgData.FirstOrDefault(p => p.id == 0x381).data;
            if ((tpdo3[0]&1) >= 1 && (tpdo3[0]&2)>=1)
            {
                return 1;
            }*/
            if (v == 0)
                return 1;
            return 0;
        }
    }
}
