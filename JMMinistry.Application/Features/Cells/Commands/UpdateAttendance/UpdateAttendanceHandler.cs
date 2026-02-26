using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Features.Cells.Queries.CellCheckIsAuthorized;
using JMMinistry.Application.Mappers;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Cell;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Cells.Commands.UpdateAttendance
{
    public class UpdateAttendanceHandler(IJmDbContext dbContext, IMediator mediator, AppMapper mapper) : ICommandHandler<UpdateAttendanceCommand, CellAttendanceDto>
    {
        public async ValueTask<CellAttendanceDto> Handle(UpdateAttendanceCommand request, CancellationToken cancellationToken)
        {
            var checkCommand = new CellCheckIsAuthorizedQuery { CellId = request.CellId, RequestorId = request.RequestorId };
            var isAuthorized = await mediator.Send(checkCommand, cancellationToken);

            if (!isAuthorized)
                throw new NotAuthorizedException();

            var attendance = await dbContext.CellAttendances
                .Include(a => a.Attendees)
                .FirstOrDefaultAsync(a => a.Id == request.AttendanceId && a.CellId == request.CellId, cancellationToken)
                ?? throw new ArgumentException("Attendance record not found");

            var cell = await dbContext.Cells
                .Include(c => c.Disciples)
                .FirstOrDefaultAsync(c => c.Id == request.CellId, cancellationToken);

            var disciples = cell?.Disciples ?? [];

            var disciplesIds = disciples.Select(d => d.Id);
            var allValidDisciples = request.Attendees.All(disciplesIds.Contains);

            if (!allValidDisciples)
                throw new ArgumentException("Not all were valid disciples");

            attendance.Attendees = [.. disciples.Where(d => request.Attendees.Contains(d.Id))];
            attendance.Notes = request.Notes;
            attendance.Date = request.Date;

            await dbContext.SaveChangesAsync(cancellationToken);

            return mapper.CellAttendanceToCellAttendanceDto(attendance);
        }
    }
}
