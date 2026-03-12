using FluentValidation;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.RecordCycleAttendance
{
    public class RecordCycleAttendanceCommand : ICommand
    {
        public required int CycleId { get; set; }
        public required int SessionId { get; set; }
        public IList<string> DiscipleIds { get; set; } = [];
    }

    public class RecordCycleAttendanceValidator : AbstractValidator<RecordCycleAttendanceCommand>
    {
        public RecordCycleAttendanceValidator()
        {
            RuleFor(x => x.SessionId).GreaterThan(0);
        }
    }
}
