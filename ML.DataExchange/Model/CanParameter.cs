namespace ML.DataExchange.Model
{
    public class CanParameter
    {
        public ushort ParameterId { get; set; }
        public byte ParameterSubIndex { get; set; }
        public byte[] Data { get; set; }
    }
}
