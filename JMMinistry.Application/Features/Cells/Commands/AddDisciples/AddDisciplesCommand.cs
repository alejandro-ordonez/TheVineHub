using FluentValidation;
using JMMinistry.Common.Dtos.Cell;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.Cells.Commands.AddDisciples
{
    public class AddDisciplesCommand: AddDisciplesDto, IRequest<CellDto>
    {
    }

    public class AddDisciplesValidator: AbstractValidator<AddDisciplesCommand>
    {
        public AddDisciplesValidator()
        {
            RuleFor(x => x.CellId)
                .NotEqual(0);

            RuleFor(x => x.Documents)
                .NotEmpty();
        }
    }
}
