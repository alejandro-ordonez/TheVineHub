namespace TheVineHub.API.Features.DiscipleJourney.Attendance
{
    public record CycleAttendanceRow
    {
        public int session_id { get; set; }
        public DateOnly session_date { get; set; }
        public string? session_topic { get; set; }
        public string disciple_id { get; set; } = null!;
        public string disciple_name { get; set; } = null!;
        public bool attended { get; set; }
        public bool is_abandoned { get; set; }
    }
}
