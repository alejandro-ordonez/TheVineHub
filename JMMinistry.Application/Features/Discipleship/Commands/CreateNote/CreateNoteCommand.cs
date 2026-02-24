using FluentValidation;
using JMMinistry.Common.Dtos.Discipleship;
using Mediator;

namespace JMMinistry.Application.Features.Discipleship.Commands.CreateNote
{
    public class CreateNoteCommand : ICommand<DiscipleshipNoteDto>
    {
        public required string DiscipleId { get; set; }
        public required string RequestorId { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = string.Empty;
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
