using System;
using System.Collections.Generic;
using System.Linq;
using ML.Can;
using ML.DataExchange.Model;

namespace ML.DataExchange
{
    static public class CanParser
    {
        public static List<Parameters> GetParametersList(List<CanDriver.canmsg_t> msgData)
        {
            var parametersList = new List<Parameters>();
            for (byte i = 1; i < 4; i++)
            {
                Parameters parameters = GetParameters(msgData, i);
                if (parameters == null)
                    return null;
                parametersList.Add(parameters);
            }
        }
        public static Parameters GetParameters(List<CanDriver.canmsg_t> msgData, byte controllerId)
        {
            if (!CheckMsgCount(msgData,controllerId))
                return null;
            Parameters parameters;
            var param = new double[30];
            var outputSignals = new List<byte>();
            var inputSignals = new List<byte>();
            for (int i = 0; i < param.Length; i++)
            {
                param[i] = 0;
            }
            try
            {
                param[0] = GetS1(msgData, controllerId);
                double v = GetV(msgData, controllerId);
                param[1] = Math.Abs(v);
                param[2] = GetA(msgData, controllerId);
                param[5] = GetStart(v);
                param[8] = GetBack(v);
                param[9] = GetOstanov(msgData, controllerId);
                param[12] = GetS2(msgData, controllerId);
                inputSignals = GetAllInputSignals(msgData, controllerId);
                outputSignals = GetAllOutputSignals(msgData, controllerId);
            }
            catch (Exception)
            {
                throw new Exception();
            }
            parameters = new Parameters(param);
            parameters.SetAuziDISignalsState(inputSignals);
            parameters.SetAuziDOSignalsState(outputSignals);
            
            return parameters;
        }

        private static bool CheckMsgCount(List<CanDriver.canmsg_t> msgData,byte controllerId)
        {
            if(msgData.All(p => p.id != (0x380 + controllerId)))
                return false;
            if (msgData.All(p => p.id != (0x280 + controllerId)))
                return false;
            if (msgData.All(p => p.id != (0x180 + controllerId)))
                return false;
            return true;
        }
        private static List<byte> GetAllOutputSignals(List<CanDriver.canmsg_t> msgData, byte controllerId)
        {
            byte[] tpdo3 = msgData.FindLast(p => p.id == (0x380 + controllerId)).data;
            byte tpdo1 = msgData.FindLast(p => p.id == (0x180 + controllerId)).data[6];
            var byteList = new List<byte> {tpdo3[4], tpdo3[5], tpdo3[6], tpdo3[7], tpdo1};
            return byteList;
        }
        private static List<byte> GetAllInputSignals(List<CanDriver.canmsg_t> msgData, byte controllerId)
        {
            byte[] tpdo3 = msgData.FindLast(p => p.id == (0x380 + controllerId)).data;
            var byteList = new List<byte> {tpdo3[0], tpdo3[1], tpdo3[2], tpdo3[3]};
            return byteList;
        }
        private static double GetS1(List<CanDriver.canmsg_t> msgData, byte controllerId)
        {
            double s = 0;
            byte[] tpdo1 = msgData.FindLast(p => p.id == (0x180 + controllerId)).data;
            s = (tpdo1[3] << 8) + (tpdo1[4] << 16) + (tpdo1[5] << 24);
            s /= 256 * 1000;
            return s;
        }
        private static double GetS2(List<CanDriver.canmsg_t> msgData, byte controllerId)
        {
            double s = 0;
            byte[] tpdo1 = msgData.FindLast(p => p.id == (0x180 + controllerId)).data;
            s = (tpdo1[0] << 8) + (tpdo1[1] << 16) + (tpdo1[2] << 24);
            s /= 256 * 1000;
            return s;
        }
        private static double GetV(List<CanDriver.canmsg_t> msgData, byte controllerId)
        {
            double v = 0;
            short sv = 0;
            byte[] tpdo2 = msgData.FindLast(p => p.id == (0x280 + controllerId)).data;
            sv = (short)((tpdo2[2]) + (tpdo2[3] << 8));
            v = sv;
            return v/1000;
        }
        private static double GetA(List<CanDriver.canmsg_t> msgData, byte controllerId)
        {
            double a = 0;
            short sa = 0;
            byte[] tpdo2 = msgData.FindLast(p => p.id  == (0x280 + controllerId)).data;
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
        private static double GetOstanov(List<CanDriver.canmsg_t> msgData, byte controllerId)
        {
            byte[] tpdo3 = msgData.FindLast(p => p.id == (0x380 + controllerId)).data;
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
