using FluentValidation;
using JMMinistry.Common.Dtos.Cell;
using MediatR;

namespace JMMinistry.Application.Features.Cells.Commands.RecordAttendance
{
    public class RecordAttendanceCommand : IRequest<CellAttendanceDto>
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
