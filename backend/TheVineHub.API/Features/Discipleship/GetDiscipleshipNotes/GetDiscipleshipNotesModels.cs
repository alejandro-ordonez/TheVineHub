using FluentValidation;
using TheVineHub.API.Features.Discipleship;
using Mediator;

namespace TheVineHub.API.Features.Discipleship.GetDiscipleshipNotes
{
    public sealed class GetDiscipleshipNotesQuery : IQuery<IList<DiscipleshipNoteDto>>
    {
        public required string RequestorId { get; init; }
        public required string DiscipleId { get; init; }
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
