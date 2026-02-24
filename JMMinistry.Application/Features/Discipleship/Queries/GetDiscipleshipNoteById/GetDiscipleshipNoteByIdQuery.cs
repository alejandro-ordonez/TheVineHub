using FluentValidation;
using JMMinistry.Common.Dtos.Discipleship;
using Mediator;

namespace JMMinistry.Application.Features.Discipleship.Queries.GetDiscipleshipNoteById
{
    public class GetDiscipleshipNoteByIdQuery : IQuery<DiscipleshipNoteDto>
    {
        public required string RequestorId { get; set; }
        public required string DiscipleId { get; set; }
        public required int NoteId { get; set; }
    }

    public class GetDiscipleshipNoteByIdValidator : AbstractValidator<GetDiscipleshipNoteByIdQuery>
    {
        public GetDiscipleshipNoteByIdValidator()
        {
            RuleFor(x => x.RequestorId).NotNull().NotEmpty();
            RuleFor(x => x.DiscipleId).NotNull().NotEmpty();
            RuleFor(x => x.NoteId).GreaterThan(0);
        }
    }
}
