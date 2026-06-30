using System.ComponentModel.DataAnnotations.Schema;
using JMMinistry.Application.Features.DiscipleJourney.Enums;

namespace JMMinistry.Application.Features.DiscipleJourney.Dtos
{
    public class CycleEnrollmentDto
    {
        [Column("id")]
        public string Id { get; set; } = string.Empty;
        [Column("disciple_id")]
        public string DiscipleId { get; set; } = string.Empty;
        [Column("disciple_name")]
        public string DiscipleName { get; set; } = string.Empty;
        [Column("cycle_staff_id")]
        public string? CycleStaffId { get; set; }
        [Column("guide_name")]
        public string? GuideName { get; set; }
        [Column("status")]
        public StepStatus Status { get; set; }
        [Column("enrolled_at")]
        public DateOnly EnrolledAt { get; set; }
        [Column("attendance_count")]
        public int AttendanceCount { get; set; }
    }
}
