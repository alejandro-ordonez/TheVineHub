using System.ComponentModel.DataAnnotations.Schema;
namespace TheVineHub.API.Features.DiscipleJourney.Enrollments
{
    public class AssignGuideRequest
    {
        public required string CycleStaffId { get; set; }
        public IList<string> EnrollmentIds { get; set; } = [];
    }
}
