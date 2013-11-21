using ML.DataRepository.Models.GenericRepository;

namespace ML.DataRepository.Models
{
    public class IOsignalState : IEntityId 
    {
        public int Id { get; set; }

        public string State { get; set; }
    }
}
