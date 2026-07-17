using FluentValidation;
using TheVineHub.API.Features.Users;
using Mediator;

namespace TheVineHub.API.Features.Cells.GetDisciples
{
    public sealed class GetDisciplesQuery : IQuery<IEnumerable<DiscipleDto>>
    {
        public required string CellId { get; init; }
        public required string RequestorId { get; init; }
    }

    public class GetDisciplesValidator : AbstractValidator<GetDisciplesQuery>
    {
        public GetDisciplesValidator()
        {
            RuleFor(x => x.RequestorId)
                .NotEmpty();

            RuleFor(x => x.CellId)
                .NotEmpty();
        }
    }
}
