using FluentValidation;
using JMMinistry.Common.Dtos.Cell;
using Mediator;

namespace JMMinistry.Application.Features.Cells.Commands.RecordAttendance
{
    public class RecordAttendanceCommand : ICommand<CellAttendanceDto>
    {
        public required int CellId { get; set; }
        public required string RequestorId { get; set; }
        public IList<string> Attendees { get; set; } = [];
        public string? Notes { get; set; }
    }

    public class RecordAttendanceValidator : AbstractValidator<RecordAttendanceCommand>
    {
        public RecordAttendanceValidator()
        {
            RuleFor(x => x.Attendees)
                .NotEmpty();
        }
    }
}
