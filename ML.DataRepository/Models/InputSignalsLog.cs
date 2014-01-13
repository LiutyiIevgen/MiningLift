using ML.DataRepository.Models.GenericRepository;

namespace ML.DataRepository.Models
{
    public class InputSignalsLog : IEntityId
    {
        public int Id { get; set; }

        public int BlockLogId { get; set; }
        public virtual BlockLog BlockLog { get; set; }

        public int IOsignalStateId { get; set; }
        public virtual IOSignalState IOsignalState { get; set; }    
    }
}
