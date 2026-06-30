using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using JMMinistry.Application.Features.Cells.Dtos;
using JMMinistry.Application.Features.Cells.Commands.AddDisciples;
using Mediator;

namespace JMMinistry.Application.Features.Cells.Commands.CreateCell
{
    public class UpsertCellCommand : CellDto, ICommand<CellDto>
    {
        [Column("document")]
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
