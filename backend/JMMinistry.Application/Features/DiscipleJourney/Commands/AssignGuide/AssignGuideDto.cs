using System.ComponentModel.DataAnnotations.Schema;
namespace JMMinistry.Application.Features.DiscipleJourney.Commands.AssignGuide
{
    public class AssignGuideDto
    {
        [Column("cycle_staff_id")]
        public required string CycleStaffId { get; set; }
        [Column("enrollment_ids")]
        public IList<string> EnrollmentIds { get; set; } = [];
    }
}
