using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DataRepository.Models
{
    class OutputSignalsLog
    {
        public int Id { get; set; }

        public int BlockLogId { get; set; }
        public virtual BlockLog BlockLog { get; set; }

        public int IOsignalStateId { get; set; }
        public virtual IOSignalState IOsignalState { get; set; } 
    }
}
