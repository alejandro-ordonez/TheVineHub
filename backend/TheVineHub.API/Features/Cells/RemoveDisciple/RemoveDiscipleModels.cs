using FluentValidation;
using TheVineHub.API.Features.Users;
using Mediator;

namespace TheVineHub.API.Features.Cells.RemoveDisciple
{
    public sealed class RemoveDiscipleCommand : ICommand<IList<DiscipleDto>>
    {
        public required string CellId { get; init; }
        public required string Document { get; init; }
    }

    public class RemoveDiscipleValidator : AbstractValidator<RemoveDiscipleCommand>
    {
        public RemoveDiscipleValidator()
        {
            RuleFor(x => x.CellId)
                .NotEmpty();

            RuleFor(x => x.Document)
                .NotEmpty();
        }
    }
}
