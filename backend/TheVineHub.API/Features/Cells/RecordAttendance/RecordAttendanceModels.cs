using FluentValidation;
using Mediator;

namespace TheVineHub.API.Features.Cells.RecordAttendance
{
    public sealed record RecordAttendanceRequest(IList<string> Disciples, string? Notes);

    public sealed class RecordAttendanceCommand : ICommand<CellAttendanceDto>
    {
        public required string CellId { get; init; }
        public required string RequestorId { get; init; }
        public IList<string> Attendees { get; init; } = [];
        public string? Notes { get; init; }
    }

    public class RecordAttendanceValidator : AbstractValidator<RecordAttendanceCommand>
    {
        public RecordAttendanceValidator()
        {
            RuleFor(x => x.Attendees)
                .NotEmpty();
            
            RuleFor(x => x.CellId)
                .NotEmpty();
        }
    }
}
