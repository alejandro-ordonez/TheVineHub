using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using JMMinistry.Application.Features.Discipleship.Dtos;
using JMMinistry.Application.Features.Discipleship.Commands.CreateNote;
using JMMinistry.Application.Features.Discipleship.Commands.CreateNoteEntry;
using JMMinistry.Application.Features.Discipleship.Enums;
using Mediator;

namespace JMMinistry.Application.Features.Discipleship.Commands.CreateNote
{
    public class CreateNoteCommand : ICommand<DiscipleshipNoteDto>
    {
        [Column("disciple_id")]
        public required string DiscipleId { get; set; }
        [Column("requestor_id")]
        public required string RequestorId { get; set; }
        [Column("title")]
        public required string Title { get; set; }
        [Column("description")]
        public string Description { get; set; } = string.Empty;
        [Column("categories")]
        public List<string> Categories { get; set; } = [];
    }

    public class CreateNoteValidator : AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteValidator()
        {
            RuleFor(x => x.DiscipleId).NotNull().NotEmpty();
            RuleFor(x => x.RequestorId).NotNull().NotEmpty();
            RuleFor(x => x.Title).NotNull().NotEmpty();
        }
    }
}
