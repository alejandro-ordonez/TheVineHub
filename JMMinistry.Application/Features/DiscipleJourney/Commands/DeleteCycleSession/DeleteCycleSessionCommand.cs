using FluentValidation;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.DeleteCycleSession
{
    public class DeleteCycleSessionCommand : ICommand
    {
        public required int CycleId { get; set; }
        public required int SessionId { get; set; }
    }

    public class DeleteCycleSessionValidator : AbstractValidator<DeleteCycleSessionCommand>
    {
        public DeleteCycleSessionValidator()
        {
            RuleFor(x => x.SessionId).GreaterThan(0);
        }
    }
}
