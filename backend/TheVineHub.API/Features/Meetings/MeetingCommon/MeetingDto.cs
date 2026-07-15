using System.ComponentModel.DataAnnotations.Schema;

namespace TheVineHub.API.Features.Meetings
{
    public class MeetingDto
    {
        [Column("meeting_id")]
        public string MeetingId { get; set; } = string.Empty;

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("start")]
        public string Start { get; set; } = "10:00:00";

        [Column("end")]
        public string End { get; set; } = "11:00:00";

        [Column("meeting_type")]
        public MeetingTypes MeetingType { get; set; }

        [Column("is_recurrent")]
        public bool IsRecurrent { get; set; }

        [Column("day_of_week")]
        public DayOfWeek? DayOfWeek { get; set; }

        [Column("date")]
        public DateOnly Date { get; set; }
    }
}
