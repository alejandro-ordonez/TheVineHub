using FluentValidation;
using TheVineHub.API.Features.Discipleship;
using Mediator;

namespace TheVineHub.API.Features.Discipleship.GetNoteEntries
{
    public sealed class GetNoteEntriesQuery : IQuery<IList<DiscipleshipNoteEntryDto>>
    {
        public required string NoteId { get; init; }
        public required string DiscipleId { get; init; }
        public required string RequestorId { get; init; }
    }

    public class GetNoteEntriesValidator : AbstractValidator<GetNoteEntriesQuery>
    {
        public GetNoteEntriesValidator()
        {
            RuleFor(x => x.NoteId).NotEmpty();
            RuleFor(x => x.DiscipleId).NotNull().NotEmpty();
            RuleFor(x => x.RequestorId).NotNull().NotEmpty();
        }
    }
}
