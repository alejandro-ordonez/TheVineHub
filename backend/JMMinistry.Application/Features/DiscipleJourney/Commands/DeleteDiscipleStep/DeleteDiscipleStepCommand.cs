using FluentValidation;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.DeleteDiscipleStep
{
    public class DeleteDiscipleStepCommand : ICommand
    {
        public required string StepId { get; set; }
    }

    public class DeleteDiscipleStepValidator : AbstractValidator<DeleteDiscipleStepCommand>
    {
        public DeleteDiscipleStepValidator()
        {
            RuleFor(x => x.StepId).NotEmpty();
        }
    }
}
