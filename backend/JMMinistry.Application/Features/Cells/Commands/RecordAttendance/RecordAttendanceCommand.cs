using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using JMMinistry.Application.Features.Cells.Dtos;
using JMMinistry.Application.Features.Cells.Commands.AddDisciples;
using Mediator;

namespace JMMinistry.Application.Features.Cells.Commands.RecordAttendance
{
    public class RecordAttendanceCommand : ICommand<CellAttendanceDto>
    {
        [Column("cell_id")]
        public required string CellId { get; set; }
        [Column("requestor_id")]
        public required string RequestorId { get; set; }
        [Column("attendees")]
        public IList<string> Attendees { get; set; } = [];
        [Column("notes")]
        public string? Notes { get; set; }
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
