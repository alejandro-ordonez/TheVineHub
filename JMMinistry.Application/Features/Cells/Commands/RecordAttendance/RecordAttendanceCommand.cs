using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.Cells.Commands.RecordAttendance
{
    public class RecordAttendanceCommand : IRequest
    {
        public required int CellId { get; set; }
        public required string RequestorId { get; set; }
        public IList<string> Attendees { get; set; } = [];
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
