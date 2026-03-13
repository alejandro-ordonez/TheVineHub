using JMMinistry.Common.Dtos.DiscipleJourney.Enums;

namespace JMMinistry.Common.Dtos.DiscipleJourney
{
    public class CycleEnrollmentSummaryDto
    {
        public string CycleName { get; set; } = string.Empty;
        public StepStatus Status { get; set; }
        public int AttendanceCount { get; set; }
        public DateOnly CycleEndDate { get; set; }
        public int MinAttendanceRequired { get; set; }
        public bool CycleEnded => CycleEndDate <= DateOnly.FromDateTime(DateTime.UtcNow);
        public bool Approved => AttendanceCount >= MinAttendanceRequired;
    }
}
