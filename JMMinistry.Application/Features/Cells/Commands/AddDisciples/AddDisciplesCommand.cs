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
        public int CellId { get; set; }
    }

    public class AddDisciplesValidator: AbstractValidator<AddDisciplesCommand>
    {
        public AddDisciplesValidator()
        {
            RuleFor(x => x.CellId)
                .Equal(0);

            RuleFor(x => x.Documents)
                .Empty();
        }
    }
}
