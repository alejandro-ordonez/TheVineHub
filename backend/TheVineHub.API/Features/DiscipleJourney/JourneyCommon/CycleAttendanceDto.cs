using System.ComponentModel.DataAnnotations.Schema;
namespace TheVineHub.API.Features.DiscipleJourney
{
    public class CycleAttendanceDto
    {
        [Column("session_id")]
        public string SessionId { get; set; } = string.Empty;
        [Column("session_date")]
        public DateOnly SessionDate { get; set; }
        [Column("session_topic")]
        public string? SessionTopic { get; set; }
        [Column("attendees")]
        public IList<CycleAttendeeDto> Attendees { get; set; } = [];
    }

    public class CycleAttendeeDto
    {
        [Column("disciple_id")]
        public string DiscipleId { get; set; } = string.Empty;
        [Column("disciple_name")]
        public string DiscipleName { get; set; } = string.Empty;
        [Column("attended")]
        public bool Attended { get; set; }
        [Column("is_abandoned")]
        public bool IsAbandoned { get; set; }
    }
}
