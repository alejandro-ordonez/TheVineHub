using FluentValidation;
using JMMinistry.Common.Dtos.Cell;
using MediatR;

namespace JMMinistry.Application.Features.Cells.Commands.CreateCell
{
    public class UpsertCellCommand : CellDto, IRequest<CellDto>
    {
        public string Document { get; set; } = string.Empty;
    }

    public class CreateCellValidator : AbstractValidator<UpsertCellCommand>
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
