namespace JMMinistry.Common.Dtos.DiscipleJourney
{
    public class CycleAttendanceDto
    {
        public int SessionId { get; set; }
        public DateOnly SessionDate { get; set; }
        public string? SessionTopic { get; set; }
        public IList<CycleAttendeeDto> Attendees { get; set; } = [];
    }

    public class CycleAttendeeDto
    {
        public string DiscipleId { get; set; } = string.Empty;
        public string DiscipleName { get; set; } = string.Empty;
        public bool Attended { get; set; }
    }
}
