using ML.DataRepository.Models.GenericRepository;

namespace ML.DataRepository.Models
{
    public class IOsignalsLog : IEntityId
    {
        public int Id { get; set; }

        public int IOsignalTypeId { get; set; }
        public int IOsignalStateId { get; set; }
        public int BlockLogId { get; set; }

        public virtual IOsignalType IOsignalType { get; set; }
        public virtual IOsignalState IOsignalState { get; set; }
        public virtual BlockLog BlockLog { get; set; }
    }
}
