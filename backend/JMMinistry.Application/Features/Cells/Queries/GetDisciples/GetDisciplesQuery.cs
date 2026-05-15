using FluentValidation;
using JMMinistry.Common.Dtos.User;
using Mediator;

namespace JMMinistry.Application.Features.Cells.Queries.GetDisciples
{
    public class GetDisciplesQuery : IQuery<IEnumerable<DiscipleDto>>
    {
        public required string CellId { get; set; }
        public required string RequestorId { get; set; }
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
