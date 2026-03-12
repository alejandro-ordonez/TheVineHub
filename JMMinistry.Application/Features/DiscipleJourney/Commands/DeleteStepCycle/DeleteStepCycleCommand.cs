using FluentValidation;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.DeleteStepCycle
{
    public class DeleteStepCycleCommand : ICommand
    {
        public required int StepId { get; set; }
        public required int CycleId { get; set; }
    }

    public class DeleteStepCycleValidator : AbstractValidator<DeleteStepCycleCommand>
    {
        public DeleteStepCycleValidator()
        {
            RuleFor(x => x.CycleId).GreaterThan(0);
        }
    }
}
