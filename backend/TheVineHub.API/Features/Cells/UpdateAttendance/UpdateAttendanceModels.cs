using FluentValidation;
using TheVineHub.API.Features.Cells;
using Mediator;

namespace TheVineHub.API.Features.Cells.UpdateAttendance
{
    public sealed record UpdateAttendanceRequest(IList<string> Disciples, string? Notes, DateTime Date);

    public sealed class UpdateAttendanceCommand : ICommand<CellAttendanceDto>
    {
        public required string CellId { get; init; }
        public required string AttendanceId { get; init; }
        public required string RequestorId { get; init; }
        public IList<string> Attendees { get; init; } = [];
        public string? Notes { get; init; }
        public DateTime Date { get; init; }
    }

    public class UpdateAttendanceValidator : AbstractValidator<UpdateAttendanceCommand>
    {
        public UpdateAttendanceValidator()
        {
            RuleFor(x => x.CellId)
                .NotEmpty();

            RuleFor(x => x.AttendanceId)
                .NotEmpty();
        }
    }
}
