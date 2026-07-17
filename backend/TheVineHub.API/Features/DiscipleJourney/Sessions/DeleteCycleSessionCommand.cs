using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using Mediator;

namespace TheVineHub.API.Features.DiscipleJourney.Sessions
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
