using JMMinistry.Common.Dtos.Meetings.Enums;

namespace JMMinistry.Common.Dtos.Meetings
{
    public class CreateMeetingDto
    {
        public string Name { get; set; } = string.Empty;
        public TimeOnly Start { get; set; } = TimeOnly.FromDateTime(DateTime.Now);
        public TimeOnly End { get; set; } = TimeOnly.FromDateTime(DateTime.Now.AddHours(1));
        public MeetingTypes MeetingTypes { get; set; }
        public bool IsRecurrent { get; set; }

        /// <summary>
        /// Day in which this event repeats
        /// </summary>
        public DayOfWeek? DayOfWeek { get; set; }

        /// <summary>
        /// Date of the event if it is not recurrent
        /// </summary>
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Today);
    }
}
