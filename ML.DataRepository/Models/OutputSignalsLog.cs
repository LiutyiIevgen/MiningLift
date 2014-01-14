using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DataRepository.Models
{
    public class OutputSignalsLog
    {
        public int Id { get; set; }

        public int BlockLogId { get; set; }

        public byte Vio7 { get; set; }
        public byte Vio8 { get; set; }
        public byte Vio9 { get; set; }
        public byte Vio11 { get; set; }
        public byte Vio12 { get; set; }
        public virtual BlockLog BlockLog { get; set; }
    }
}
