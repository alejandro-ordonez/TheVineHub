using JMMinistry.Common.Dtos.Gained.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Domain
{
    public class GainedEvent
    {
        [Key]
        public int EventId { get; set; }

        public int GainedId { get; set; }
        public Gained? Gained { get; set; }

        public GainedEventType EventType { get; set; }
        public string? Observations { get; set; }
    }
}
