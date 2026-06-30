using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using JMMinistry.Application.Features.DiscipleJourney.Enums;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateStepCompletion
{
    public class UpdateStepCompletionCommand : ICommand
    {
        [Column("step_id")]
        public required string StepId { get; set; }
        [Column("disciple_id")]
        public required string DiscipleId { get; set; }
        [Column("step_status")]
        public required StepStatus StepStatus { get; set; }
        [Column("completion_date")]
        public DateOnly? CompletionDate { get; set; }
    }

    public class UpdateStepCompletionValidator : AbstractValidator<UpdateStepCompletionCommand>
    {
        public UpdateStepCompletionValidator()
        {
            RuleFor(x => x.StepId).NotEmpty();
            RuleFor(x => x.DiscipleId).NotEmpty();
            RuleFor(x => x.StepStatus).IsInEnum();
        }
    }
}
