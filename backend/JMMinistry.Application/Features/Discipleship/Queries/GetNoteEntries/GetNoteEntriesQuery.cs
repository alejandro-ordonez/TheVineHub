using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using JMMinistry.Application.Features.Discipleship.Dtos;
using JMMinistry.Application.Features.Discipleship.Commands.CreateNote;
using JMMinistry.Application.Features.Discipleship.Commands.CreateNoteEntry;
using JMMinistry.Application.Features.Discipleship.Enums;
using Mediator;

namespace JMMinistry.Application.Features.Discipleship.Queries.GetNoteEntries
{
    public class GetNoteEntriesQuery : IQuery<IList<DiscipleshipNoteEntryDto>>
    {
        [Column("note_id")]
        public required string NoteId { get; set; }
        [Column("disciple_id")]
        public required string DiscipleId { get; set; }
        [Column("requestor_id")]
        public required string RequestorId { get; set; }
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
