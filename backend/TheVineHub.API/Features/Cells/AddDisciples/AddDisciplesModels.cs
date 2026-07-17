using FluentValidation;
using TheVineHub.API.Features.Users;
using Mediator;

namespace TheVineHub.API.Features.Cells.AddDisciples
{
    public sealed record AddDisciplesRequest(IList<string> Documents);

    public sealed class AddDisciplesCommand : ICommand<List<DiscipleDto>>
    {
        public required string CellId { get; init; }
        public IList<string> Documents { get; init; } = [];
    }

    public class AddDisciplesValidator : AbstractValidator<AddDisciplesCommand>
    {
        public AddDisciplesValidator()
        {
            RuleFor(x => x.CellId)
                .NotEmpty();

            RuleFor(x => x.Documents)
                .NotEmpty();
        }
    }
}
