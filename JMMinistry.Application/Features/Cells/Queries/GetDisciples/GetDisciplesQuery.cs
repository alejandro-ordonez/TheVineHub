using FluentValidation;
using JMMinistry.Common.Dtos.Common;
using JMMinistry.Common.Dtos.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.Cells.Queries.GetDisciples
{
    public class GetDisciplesQuery: IRequest<IEnumerable<PartialUserInfoDto>>
    {
        public required int CellId { get; set; }
        public required string RequestorId { get; set; }
    }

    public class GetDisciplesValidator: AbstractValidator<GetDisciplesQuery>
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
