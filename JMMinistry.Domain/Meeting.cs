using JMMinistry.Common.Dtos.Meetings.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Domain
{
    public class Meeting
    {
        public int Id { get; set; }
        public TimeOnly Start { get; set; }
        public TimeOnly End { get; set; }
        public required string Name { get; set; }
        public bool IsRecurrent { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }
        public DateOnly? Date { get; set; }
        public MeetingTypes MeetingType { get; set; }

        public IList<MeetingAttendance> MeetingAttendances { get; set; } = [];
    }
}
