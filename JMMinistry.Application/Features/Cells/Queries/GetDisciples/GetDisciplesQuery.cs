using FluentValidation;
using JMMinistry.Common.Dtos.User;
using MediatR;

namespace JMMinistry.Application.Features.Cells.Queries.GetDisciples
{
    public class GetDisciplesQuery : IRequest<IEnumerable<PartialUserInfoDto>>
    {
        public required int CellId { get; set; }
        public required string RequestorId { get; set; }
    }

    public class GetDisciplesValidator : AbstractValidator<GetDisciplesQuery>
    {
        public GetDisciplesValidator()
        {
            RuleFor(x => x.RequestorId)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.CellId)
                .GreaterThan(0);
        }
    }

}
