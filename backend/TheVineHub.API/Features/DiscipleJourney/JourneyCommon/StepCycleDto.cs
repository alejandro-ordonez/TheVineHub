using System.ComponentModel.DataAnnotations.Schema;
using SurrealDb.Net.Models;

namespace TheVineHub.API.Features.DiscipleJourney
{
    public class StepCycleDto
    {
        [Column("id")]
        public RecordId? Id { get; set; }
        [Column("disciple_step_id")]
        public RecordId? DiscipleStepId { get; set; }
        [Column("name")]
        public string Name { get; set; } = string.Empty;
        [Column("start_date")]
        public DateOnly StartDate { get; set; }
        [Column("end_date")]
        public DateOnly EndDate { get; set; }
        [Column("min_attendance_required")]
        public int MinAttendanceRequired { get; set; }
        [Column("is_open")]
        public bool IsOpen { get; set; }
        [Column("enrollment_deadline")]
        public DateOnly? EnrollmentDeadline { get; set; }
        [Column("session_count")]
        public int SessionCount { get; set; }
        [Column("enrolled_count")]
        public int EnrolledCount { get; set; }
    }
}
