using System.ComponentModel.DataAnnotations.Schema;
using TheVineHub.API.Features.DiscipleJourney;

namespace TheVineHub.API.Features.DiscipleJourney.Enrollments
{
    public class UpdateEnrollmentStatusRequest
    {
        public StepStatus Status { get; set; }
    }
}
