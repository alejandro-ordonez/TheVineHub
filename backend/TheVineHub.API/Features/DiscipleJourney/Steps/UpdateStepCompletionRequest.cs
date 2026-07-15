using System.ComponentModel.DataAnnotations.Schema;
using TheVineHub.API.Features.DiscipleJourney;

namespace TheVineHub.API.Features.DiscipleJourney.Steps
{
    public class UpdateStepCompletionRequest
    {
        public StepStatus Status { get; set; }
        public DateOnly? CompletionDate { get; set; }
    }
}
