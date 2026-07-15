using Mediator;
using FluentValidation;

namespace TheVineHub.API.Features.Discipleship.CreateNoteEntry
{
    public sealed record CreateNoteEntryRequest(string Content, DateTime Date);

    public sealed class CreateNoteEntryCommand : ICommand<DiscipleshipNoteEntryDto>
    {
        public required string NoteId { get; init; }
        public required string DiscipleId { get; init; }
        public required string RequestorId { get; init; }
        public required string Content { get; init; }
        public DateTime Date { get; init; }
    }

    public class CreateNoteEntryValidator : AbstractValidator<CreateNoteEntryCommand>
    {
        public CreateNoteEntryValidator()
        {
            RuleFor(x => x.NoteId).NotEmpty();
            RuleFor(x => x.DiscipleId).NotNull().NotEmpty();
            RuleFor(x => x.RequestorId).NotNull().NotEmpty();
            RuleFor(x => x.Content).NotNull().NotEmpty();
        }
    }
}
