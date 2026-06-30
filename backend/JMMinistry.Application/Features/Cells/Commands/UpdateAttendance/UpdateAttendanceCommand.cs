using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using JMMinistry.Application.Features.Cells.Dtos;
using JMMinistry.Application.Features.Cells.Commands.AddDisciples;
using Mediator;

namespace JMMinistry.Application.Features.Cells.Commands.UpdateAttendance
{
    public class UpdateAttendanceCommand : ICommand<CellAttendanceDto>
    {
        [Column("cell_id")]
        public required string CellId { get; set; }
        [Column("attendance_id")]
        public required string AttendanceId { get; set; }
        [Column("requestor_id")]
        public required string RequestorId { get; set; }
        [Column("attendees")]
        public IList<string> Attendees { get; set; } = [];
        [Column("notes")]
        public string? Notes { get; set; }
        [Column("date")]
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
