using System.ComponentModel.DataAnnotations.Schema;
namespace JMMinistry.Application.Features.DiscipleJourney.Commands.CompleteStepForDisciples
{
    public class CompleteStepDto
    {
        [Column("documents")]
        public IList<string> Documents { get; set; } = [];
        [Column("completion_date")]
        public DateOnly CompletionDate { get; set; }
    }
}
