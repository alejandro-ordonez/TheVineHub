using System.ComponentModel.DataAnnotations.Schema;
using TheVineHub.API.Features.DiscipleJourney;

namespace TheVineHub.API.Features.DiscipleJourney.Enrollments
{
    public class EnrollDisciplesRequest
    {
        public IList<string> DiscipleIds { get; set; } = [];
        public StepStatus? InitialStatus { get; set; }
    }
}
