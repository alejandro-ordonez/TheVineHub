using FluentValidation;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateStepCompletion
{
    public class UpdateStepCompletionCommand : ICommand
    {
        public required int StepId { get; set; }
        public required string DiscipleId { get; set; }
        public required Domain.DiscipleJourney.StepStatus StepStatus { get; set; }
    }

    public class UpdateStepCompletionValidator : AbstractValidator<UpdateStepCompletionCommand>
    {
        public UpdateStepCompletionValidator()
        {
            RuleFor(x => x.StepId).GreaterThan(0);
            RuleFor(x => x.DiscipleId).NotEmpty();
            RuleFor(x => x.StepStatus).IsInEnum();
        }
    }
}
