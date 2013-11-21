using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML.DataRepository.Models.GenericRepository;

namespace ML.DataRepository.Models
{
    public class MainDigitSignalsLog : IEntityId
    {
        public int Id { get; set; }

        public int MainDigitSignalTypeId { get; set; }
        public int MainDigitSignalStateId { get; set; }
        public int BlockLogId { get; set; }

        public virtual IOsignalType MainDigitSignalType { get; set; }
        public virtual IOsignalState MainDigitSignalState { get; set; }
        public virtual BlockLog BlockLog { get; set; }
    }
}
