using FluentValidation;
using JMMinistry.Common.Dtos.Discipleship;
using Mediator;

namespace JMMinistry.Application.Features.Discipleship.Queries.GetNoteEntries
{
    public class GetNoteEntriesQuery : IQuery<IList<DiscipleshipNoteEntryDto>>
    {
        public required int NoteId { get; set; }
        public required string DiscipleId { get; set; }
        public required string RequestorId { get; set; }
    }

    public class GetNoteEntriesValidator : AbstractValidator<GetNoteEntriesQuery>
    {
        public GetNoteEntriesValidator()
        {
            RuleFor(x => x.NoteId).GreaterThan(0);
            RuleFor(x => x.DiscipleId).NotNull().NotEmpty();
            RuleFor(x => x.RequestorId).NotNull().NotEmpty();
        }
    }
}
