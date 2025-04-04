using JMMinistry.Common.Dtos.Meetings.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Common.Dtos.Meetings
{
    public class CreateMeetingDto
    {
        public string Name { get; set; } = string.Empty;
        public TimeOnly Start { get; set; }
        public TimeOnly End { get; set; }
        public MeetingTypes MeetingTypes { get; set; }
        public bool IsRecurrent { get; set; }

        /// <summary>
        /// Day in which this event repeats
        /// </summary>
        public DayOfWeek? Day { get; set; }

        /// <summary>
        /// Date of the event if it is not recurrent
        /// </summary>
        public DateOnly Date { get; set; }
    }
}
