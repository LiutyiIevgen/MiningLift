using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ML.DataExchange.CanDriver;

namespace ML.DataExchange
{
    static class CanParser
    {
        public static List<CanParameter> TryGetParameterValue(List<AdvCan.canmsg_t> msgData)
        {
            var canParameters = new List<CanParameter>();
            var msgList = msgData.Where(m => m.id == 0x581).ToList();
            if (msgList.Count != 0)
            {
                foreach (var canmsgT in msgList)
                {
                    canParameters.Add(new CanParameter
                    {
                        ParameterId = (ushort)(canmsgT.data[1] + (canmsgT.data[2]<<8)),
                        ParameterSubIndex = canmsgT.data[3],
                        Data = new byte[] { canmsgT.data[4], canmsgT.data[5], canmsgT.data[6], canmsgT.data[7] }
                    });
                }
            }
            return canParameters;

        }
        public static List<AuziDState> GetAllOutputSignals(List<AdvCan.canmsg_t> msgData)
        {
            List<AuziDState> signals = new List<AuziDState>();
            byte[] tpdo3 = msgData.FirstOrDefault(p => p.id == 0x381).data;
            byte tpdo1 = msgData.FirstOrDefault(p => p.id == 0x181).data[6];
            var byteList = new List<byte> {tpdo3[4], tpdo3[5], tpdo3[6], tpdo3[7], tpdo1};
            foreach (var _byte in byteList)
            {
                byte b = _byte;
                for (int i = 0; i < 8; i++)
                {
                    signals.Add((b & 0x01) == 1 ? AuziDState.Off : AuziDState.On);
                    b = (byte)(b >> 1);
                }
            }
            return signals;
        }
        public static List<AuziDState> GetAllInputSignals(List<AdvCan.canmsg_t> msgData)
        {
            List<AuziDState> signals = new List<AuziDState>();
            byte[] tpdo3 = msgData.FirstOrDefault(p => p.id == 0x381).data;
            var byteList = new List<byte> {tpdo3[0], tpdo3[1], tpdo3[2], tpdo3[3]};
            foreach (var _byte in byteList)
            {
                byte b = _byte;
                for (int i = 0; i < 8; i++)
                {
                    signals.Add((b & 0x01) == 1 ? AuziDState.Off : AuziDState.On);
                    b = (byte)(b >> 1);
                }
            }
            return signals;
        }
        public static double GetS1(List<AdvCan.canmsg_t> msgData)
        {
            double s = 0;
            byte[] tpdo1 = msgData.FirstOrDefault(p => p.id == 0x181).data;
            s = (tpdo1[3] << 8) + (tpdo1[4] << 16) + (tpdo1[5] << 24);
            s /= 256 * 1000;
            return s;
        }
        public static double GetS2(List<AdvCan.canmsg_t> msgData)
        {
            double s = 0;
            byte[] tpdo1 = msgData.FirstOrDefault(p => p.id == 0x181).data;
            s = (tpdo1[0] << 8) + (tpdo1[1] << 16) + (tpdo1[2] << 24);
            s /= 256 * 1000;
            return s;
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
        public static double GetOstanov(List<AdvCan.canmsg_t> msgData)
        {
            byte[] tpdo3 = msgData.FirstOrDefault(p => p.id == 0x381).data;
            if ((tpdo3[0]&1) >= 1 && (tpdo3[0]&2)>=1)
            {
                return 1;
            }
            /*if (v == 0)
                return 1;*/
            return 0;
        }


    }
}
