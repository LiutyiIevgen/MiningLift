namespace ML.DataRepository.Models
{
    public class AnalogSignalLog
    {
        public int Id { get; set; }

        public int BlockLogId { get; set; }
        public int SignalTypeId { get; set; }

        public int SignalValue { get; set; }

        public virtual BlockLog BlockLog { get; set; }
        public virtual AnalogSignal SignalType { get; set; }
    }
}
