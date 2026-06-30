using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using Mediator;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.RecordCycleAttendance
{
    public class RecordCycleAttendanceCommand : ICommand
    {
        [Column("cycle_id")]
        public required string CycleId { get; set; }
        [Column("session_id")]
        public required string SessionId { get; set; }
        [Column("disciple_ids")]
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
