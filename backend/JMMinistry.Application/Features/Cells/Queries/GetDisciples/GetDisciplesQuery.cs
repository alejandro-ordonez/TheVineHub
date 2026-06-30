using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using JMMinistry.Application.Features.User.Dtos;
using JMMinistry.Application.Features.User.Commands.Authenticate;
using JMMinistry.Application.Features.User.Commands.CreateUser;
using JMMinistry.Application.Features.User.Commands.MarryLeaders;
using Mediator;

namespace JMMinistry.Application.Features.Cells.Queries.GetDisciples
{
    public class GetDisciplesQuery : IQuery<IEnumerable<DiscipleDto>>
    {
        [Column("cell_id")]
        public required string CellId { get; set; }
        [Column("requestor_id")]
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
