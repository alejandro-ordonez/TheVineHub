using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using TheVineHub.API.Features.DiscipleJourney;
using Mediator;

namespace TheVineHub.API.Features.DiscipleJourney.Steps
{
    public class UpdateStepCompletionCommand : ICommand
    {
        public required string StepId { get; set; }
        public required string DiscipleId { get; set; }
        public required StepStatus StepStatus { get; set; }
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
