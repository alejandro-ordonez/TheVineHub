using System.ComponentModel.DataAnnotations.Schema;
namespace JMMinistry.Application.Features.DiscipleJourney.Commands.CreateStepCycle
{
    public class CreateStepCycleDto
    {
        [Column("name")]
        public required string Name { get; set; }
        [Column("start_date")]
        public DateOnly StartDate { get; set; }
        [Column("end_date")]
        public DateOnly EndDate { get; set; }
        [Column("min_attendance_required")]
        public int MinAttendanceRequired { get; set; }
        [Column("enrollment_deadline")]
        public DateOnly? EnrollmentDeadline { get; set; }
    }
}
