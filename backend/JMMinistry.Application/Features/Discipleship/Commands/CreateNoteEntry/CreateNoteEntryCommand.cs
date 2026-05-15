using FluentValidation;
using JMMinistry.Common.Dtos.Discipleship;
using Mediator;

namespace JMMinistry.Application.Features.Discipleship.Commands.CreateNoteEntry
{
    public class CreateNoteEntryCommand : ICommand<DiscipleshipNoteEntryDto>
    {
        public required string NoteId { get; set; }
        public required string DiscipleId { get; set; }
        public required string RequestorId { get; set; }
        public required string Content { get; set; }
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
