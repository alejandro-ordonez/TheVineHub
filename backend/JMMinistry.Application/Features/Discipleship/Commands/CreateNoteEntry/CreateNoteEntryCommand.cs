using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using JMMinistry.Application.Features.Discipleship.Dtos;
using JMMinistry.Application.Features.Discipleship.Commands.CreateNote;
using JMMinistry.Application.Features.Discipleship.Commands.CreateNoteEntry;
using JMMinistry.Application.Features.Discipleship.Enums;
using Mediator;

namespace JMMinistry.Application.Features.Discipleship.Commands.CreateNoteEntry
{
    public class CreateNoteEntryCommand : ICommand<DiscipleshipNoteEntryDto>
    {
        [Column("note_id")]
        public required string NoteId { get; set; }
        [Column("disciple_id")]
        public required string DiscipleId { get; set; }
        [Column("requestor_id")]
        public required string RequestorId { get; set; }
        [Column("content")]
        public required string Content { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
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
