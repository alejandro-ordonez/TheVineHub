using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.Cells.Commands.RemoveDisciple
{
    public class RemoveDiscipleCommand: IRequest<string>
    {
        public required int CellId { get; set; }
        public required string Document { get; set; }
    }

    public class RemoveDiscipleValidator : AbstractValidator<RemoveDiscipleCommand>
    {
        public RemoveDiscipleValidator()
        {
            RuleFor(x => x.CellId)
                .GreaterThan(0);

            RuleFor(x => x.Document)
                .NotEmpty();
        }
    }
}
