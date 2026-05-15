using FluentValidation;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.DeleteCycleSession
{
    public class DeleteCycleSessionCommand : ICommand
    {
        public required string CycleId { get; set; }
        public required string SessionId { get; set; }
    }

    public class DeleteCycleSessionValidator : AbstractValidator<DeleteCycleSessionCommand>
    {
        public DeleteCycleSessionValidator()
        {
            RuleFor(x => x.SessionId).NotEmpty();
            RuleFor(x => x.CycleId).NotEmpty();
        }
    }
}
