using FluentValidation;
using TheVineHub.API.Features.Discipleship;
using Mediator;

namespace TheVineHub.API.Features.Discipleship.GetDiscipleshipNoteById
{
    public sealed class GetDiscipleshipNoteByIdQuery : IQuery<DiscipleshipNoteDto>
    {
        public required string RequestorId { get; init; }
        public required string DiscipleId { get; init; }
        public required string NoteId { get; init; }
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
