using JMMinistry.Common.Dtos.Gained.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Common.Dtos.Gained
{
    public class GainedEvent
    {
        public int Id { get; set; }
        public GainedEventType EventType { get; set; }
        public string Observations { get; set; } = string.Empty;
    }
}
