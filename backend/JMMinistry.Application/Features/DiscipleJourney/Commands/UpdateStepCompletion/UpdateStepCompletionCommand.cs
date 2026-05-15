using FluentValidation;
using JMMinistry.Common.Dtos.DiscipleJourney.Enums;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateStepCompletion
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
