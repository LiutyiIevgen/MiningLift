using System;
using System.ComponentModel.DataAnnotations.Schema;
using ML.DataRepository.Models.GenericRepository;

namespace ML.DataRepository.Models
{
    public class RemoteLog : IEntityId
    {
        public int Id { get; set; }
        public int FanObjectNum { get; set; }
        public DateTime Date { get; set; }
        public string Person { get; set; }
         [ForeignKey("RemoteState")]
        public int RemoteStateId { get; set; }
        public bool Sent { get; set; }

        public virtual RemoteState RemoteState { get; set; }
    }
}
