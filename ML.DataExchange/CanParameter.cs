using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ML.DataExchange
{
    public class CanParameter
    {
        public ushort ParameterId { get; set; }
        public byte ParameterSubIndex { get; set; }
        public byte[] Data { get; set; }
    }
}
