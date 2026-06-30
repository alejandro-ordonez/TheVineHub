using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using JMMinistry.Application.Features.Discipleship.Dtos;
using JMMinistry.Application.Features.Discipleship.Commands.CreateNote;
using JMMinistry.Application.Features.Discipleship.Commands.CreateNoteEntry;
using JMMinistry.Application.Features.Discipleship.Enums;
using Mediator;

namespace JMMinistry.Application.Features.Discipleship.Queries.GetDiscipleshipNotes
{
    public class GetDiscipleshipNotesQuery : IQuery<IList<DiscipleshipNoteDto>>
    {
        [Column("requestor_id")]
        public required string RequestorId { get; set; }
        [Column("disciple_id")]
        public required string DiscipleId { get; set; }
    }

    public class GetDiscipleshipNotesValidator : AbstractValidator<GetDiscipleshipNotesQuery>
    {
        public GetDiscipleshipNotesValidator()
        {
            RuleFor(x => x.RequestorId).NotNull().NotEmpty();
            RuleFor(x => x.DiscipleId).NotNull().NotEmpty();
        }
    }
}
