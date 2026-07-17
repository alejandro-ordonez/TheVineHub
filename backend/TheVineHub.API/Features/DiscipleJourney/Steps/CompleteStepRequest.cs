using System.ComponentModel.DataAnnotations.Schema;
namespace TheVineHub.API.Features.DiscipleJourney.Steps
{
    public class CompleteStepRequest
    {
        public IList<string> Documents { get; set; } = [];
        public DateOnly CompletionDate { get; set; }
    }
}
