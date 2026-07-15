using Mediator;
using FluentValidation;
using SurrealDb.Net.Models;

namespace TheVineHub.API.Features.Cells.UpsertCell
{
    public sealed class UpsertCellCommand : ICommand<CellDto>
    {
        public RecordId? Id { get; init; }
        public required string Document { get; init; }
        public required string Name { get; init; }
        public string Description { get; init; } = string.Empty;
        public bool MainCell { get; init; }
        public string Address { get; init; } = string.Empty;
        public DayOfWeek? Day { get; init; }
        public DateOnly? OpeningDate { get; init; }
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
