using System.ComponentModel.DataAnnotations.Schema;
using JMMinistry.Application.Features.DiscipleJourney.Enums;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateStepCompletion
{
    public class UpdateStepCompletionDto
    {
        [Column("status")]
        public StepStatus Status { get; set; }
        [Column("completion_date")]
        public DateOnly? CompletionDate { get; set; }
    }
}
