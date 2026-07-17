using Mediator;
using FluentValidation;

namespace TheVineHub.API.Features.Discipleship.CreateNote
{
    public sealed record CreateNoteRequest(
        string Title,
        string Description,
        List<string> Categories
    );

    public sealed class CreateNoteCommand : ICommand<DiscipleshipNoteDto>
    {
        public required string DiscipleId { get; init; }
        public required string RequestorId { get; init; }
        public required string Title { get; init; }
        public string Description { get; init; } = string.Empty;
        public List<string> Categories { get; init; } = [];
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
