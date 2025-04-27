using JMMinistry.Common.Dtos.Gained.Enums;
using System.ComponentModel.DataAnnotations;

namespace JMMinistry.Domain
{
    public class GainedEvent
    {
        [Key]
        public int EventId { get; set; }

        public int GainedId { get; set; }
        public Gained? Gained { get; set; }

        public GainedEventType EventType { get; set; }
        public DateOnly Date { get; set; }
        public string? Observations { get; set; }
    }
}
