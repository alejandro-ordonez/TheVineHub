using System.ComponentModel.DataAnnotations.Schema;
using JMMinistry.Application.Features.DiscipleJourney.Enums;

namespace JMMinistry.Application.Features.DiscipleJourney.Dtos
{
    public class CycleEnrollmentSummaryDto
    {
        [Column("cycle_name")]
        public string CycleName { get; set; } = string.Empty;
        [Column("status")]
        public StepStatus Status { get; set; }
        [Column("attendance_count")]
        public int AttendanceCount { get; set; }
        [Column("cycle_end_date")]
        public DateOnly CycleEndDate { get; set; }
        [Column("min_attendance_required")]
        public int MinAttendanceRequired { get; set; }
        public bool CycleEnded => CycleEndDate <= DateOnly.FromDateTime(DateTime.UtcNow);
        public bool Approved => AttendanceCount >= MinAttendanceRequired;
    }
}
