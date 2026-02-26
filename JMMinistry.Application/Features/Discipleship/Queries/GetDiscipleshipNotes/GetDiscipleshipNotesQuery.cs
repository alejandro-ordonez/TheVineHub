using FluentValidation;
using JMMinistry.Common.Dtos.Discipleship;
using Mediator;

namespace JMMinistry.Application.Features.Discipleship.Queries.GetDiscipleshipNotes
{
    public class GetDiscipleshipNotesQuery : IQuery<IList<DiscipleshipNoteDto>>
    {
        public required string RequestorId { get; set; }
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
