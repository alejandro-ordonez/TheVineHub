using FluentValidation;
using JMMinistry.Common.Dtos.Cell;
using Mediator;

namespace JMMinistry.Application.Features.Cells.Commands.CreateCell
{
    public class UpsertCellCommand : CellDto, ICommand<CellDto>
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
