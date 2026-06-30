using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using JMMinistry.Application.Features.Discipleship.Dtos;
using JMMinistry.Application.Features.Discipleship.Commands.CreateNote;
using JMMinistry.Application.Features.Discipleship.Commands.CreateNoteEntry;
using JMMinistry.Application.Features.Discipleship.Enums;
using Mediator;

namespace JMMinistry.Application.Features.Discipleship.Queries.GetDiscipleshipNoteById
{
    public class GetDiscipleshipNoteByIdQuery : IQuery<DiscipleshipNoteDto>
    {
        [Column("requestor_id")]
        public required string RequestorId { get; set; }
        [Column("disciple_id")]
        public required string DiscipleId { get; set; }
        [Column("note_id")]
        public required string NoteId { get; set; }
    }

    public class GetDiscipleshipNoteByIdValidator : AbstractValidator<GetDiscipleshipNoteByIdQuery>
    {
        public GetDiscipleshipNoteByIdValidator()
        {
            RuleFor(x => x.RequestorId).NotNull().NotEmpty();
            RuleFor(x => x.DiscipleId).NotNull().NotEmpty();
            RuleFor(x => x.NoteId).NotEmpty();
        }
    }
}
