using FluentValidation;
using JMMinistry.Common.Dtos.Cell;
using Mediator;

namespace JMMinistry.Application.Features.Cells.Commands.UpdateAttendance
{
    public class UpdateAttendanceCommand : ICommand<CellAttendanceDto>
    {
        public required string CellId { get; set; }
        public required string AttendanceId { get; set; }
        public required string RequestorId { get; set; }
        public IList<string> Attendees { get; set; } = [];
        public string? Notes { get; set; }
        public DateTime Date { get; set; }
    }

    public class UpdateAttendanceValidator : AbstractValidator<UpdateAttendanceCommand>
    {
        public UpdateAttendanceValidator()
        {
            RuleFor(x => x.Attendees)
                .NotEmpty();

            RuleFor(x => x.CellId)
                .NotEmpty();

            RuleFor(x => x.AttendanceId)
                .NotEmpty();
        }
    }
}
