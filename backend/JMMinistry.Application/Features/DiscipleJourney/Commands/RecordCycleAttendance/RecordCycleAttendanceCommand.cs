using FluentValidation;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.RecordCycleAttendance
{
    public class RecordCycleAttendanceCommand : ICommand
    {
        public required string CycleId { get; set; }
        public required string SessionId { get; set; }
        public IList<string> DiscipleIds { get; set; } = [];
    }

    public class RecordCycleAttendanceValidator : AbstractValidator<RecordCycleAttendanceCommand>
    {
        public RecordCycleAttendanceValidator()
        {
            RuleFor(x => x.SessionId).NotEmpty();
            RuleFor(x => x.CycleId).NotEmpty();
        }
    }
}
