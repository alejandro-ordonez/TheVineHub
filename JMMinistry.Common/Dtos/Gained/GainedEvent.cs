using JMMinistry.Common.Dtos.Gained.Enums;

namespace JMMinistry.Common.Dtos.Gained
{
    public class GainedEvent
    {
        public int Id { get; set; }
        public GainedEventType EventType { get; set; }
        public string Observations { get; set; } = string.Empty;
    }
}
