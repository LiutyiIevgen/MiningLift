using System;
using System.Collections.Generic;
using System.Linq;
using ML.Can;
using ML.DataExchange.Model;

namespace ML.DataExchange
{
    static public class CanParser
    {
        public static Parameters GetParameters(List<CanDriver.canmsg_t> msgData)
        {
            Parameters parameters;
            var param = new double[30];
            var outputSignals = new List<AuziDState>();
            var inputSignals = new List<AuziDState>();
            for (int i = 0; i < param.Length; i++)
            {
                param[i] = 0;
            }
            try
            {
                param[0] = GetS1(msgData);
                double v = GetV(msgData);
                param[1] = Math.Abs(v);
                param[2] = GetA(msgData);
                param[5] = GetStart(v);
                param[8] = GetBack(v);
                param[9] = GetOstanov(msgData);
                param[12] = GetS2(msgData);
                inputSignals = GetAllInputSignals(msgData);
                outputSignals = GetAllOutputSignals(msgData);
            }
            catch (Exception)
            {
                throw new Exception();
            }
            parameters = new Parameters(param);
            parameters.SetAuziDOSignalsState(outputSignals);
            parameters.SetAuziDISignalsState(inputSignals);
            return parameters;
        }

        private static List<AuziDState> GetAllOutputSignals(List<CanDriver.canmsg_t> msgData)
        {
            List<AuziDState> signals = new List<AuziDState>();
            byte[] tpdo3 = msgData.FirstOrDefault(p => (p.id & 0xF80) == 0x380).data;
            byte tpdo1 = msgData.FirstOrDefault(p => (p.id & 0xF80) == 0x180).data[6];
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
        private static List<AuziDState> GetAllInputSignals(List<CanDriver.canmsg_t> msgData)
        {
            List<AuziDState> signals = new List<AuziDState>();
            byte[] tpdo3 = msgData.FirstOrDefault(p => (p.id & 0xF80) == 0x380).data;
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
        private static double GetS1(List<CanDriver.canmsg_t> msgData)
        {
            double s = 0;
            byte[] tpdo1 = msgData.FirstOrDefault(p => (p.id & 0xF80) == 0x180).data;
            s = (tpdo1[3] << 8) + (tpdo1[4] << 16) + (tpdo1[5] << 24);
            s /= 256 * 1000;
            return s;
        }
        private static double GetS2(List<CanDriver.canmsg_t> msgData)
        {
            double s = 0;
            byte[] tpdo1 = msgData.FindLast(p => (p.id & 0xF80) == 0x180).data;
            s = (tpdo1[0] << 8) + (tpdo1[1] << 16) + (tpdo1[2] << 24);
            s /= 256 * 1000;
            return s;
        }
        private static double GetV(List<CanDriver.canmsg_t> msgData)
        {
            double v = 0;
            short sv = 0;
            byte[] tpdo2 = msgData.FindLast(p => (p.id & 0xF80) == 0x280).data;
            sv = (short)((tpdo2[2]) + (tpdo2[3] << 8));
            v = sv;
            return v/1000;
        }
        private static double GetA(List<CanDriver.canmsg_t> msgData)
        {
            double a = 0;
            short sa = 0;
            byte[] tpdo2 = msgData.FindLast(p => (p.id & 0xF80) == 0x280).data;
            sa = (short)((tpdo2[6]) + (tpdo2[7] << 8));
            a = sa;
            return a / 1000;
        }
        private static double GetStart(double v)
        {
            if (v < 0)
                return 1;
            return 0;
        }
        private static double GetBack(double v)
        {
            if (v >= 0)
                return 1;
            return 0;
        }
        private static double GetOstanov(List<CanDriver.canmsg_t> msgData)
        {
            byte[] tpdo3 = msgData.FindLast(p => (p.id & 0xF80) == 0x380).data;
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
