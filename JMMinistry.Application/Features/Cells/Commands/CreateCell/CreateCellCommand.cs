using FluentValidation;
using JMMinistry.Common.Dtos.Cell;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.Cells.Commands.CreateCell
{
    public class CreateCellCommand: CreateCellDto, IRequest<CellDto>
    {
        public string Document { get; set; } = string.Empty;
    }

    public class CreateCellValidator: AbstractValidator<CreateCellCommand>
    {
        public CreateCellValidator()
        {
            RuleFor(x => x.Document)
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
