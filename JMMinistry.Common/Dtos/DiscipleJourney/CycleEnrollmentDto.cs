using JMMinistry.Common.Dtos.DiscipleJourney.Enums;

namespace JMMinistry.Common.Dtos.DiscipleJourney
{
    public class CycleEnrollmentDto
    {
        public int Id { get; set; }
        public string DiscipleId { get; set; } = string.Empty;
        public string DiscipleName { get; set; } = string.Empty;
        public int? CycleStaffId { get; set; }
        public string? GuideName { get; set; }
        public StepStatus Status { get; set; }
        public DateOnly EnrolledAt { get; set; }
        public int AttendanceCount { get; set; }
    }
}
