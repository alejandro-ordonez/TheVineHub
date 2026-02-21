using FluentValidation;
using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Features.Cells.Queries.CellCheckIsAuthorized;
using JMMinistry.Application.Mappers;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Domain;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Cells.Commands.RecordAttendance
{
    public class RecordAttendanceHandler(IJmDbContext dbContext, IMediator mediator, AppMapper mapper) : ICommandHandler<RecordAttendanceCommand, CellAttendanceDto>
    {
        public async ValueTask<CellAttendanceDto> Handle(RecordAttendanceCommand request, CancellationToken cancellationToken)
        {
            var checkCommand = new CellCheckIsAuthorizedQuery { CellId = request.CellId, RequestorId = request.RequestorId };
            var isAuthorized = await mediator.Send(checkCommand, cancellationToken);

            if (!isAuthorized)
                throw new NotAuthorizedException();

            var cell = await dbContext.Cells
                .Include(cell => cell.Disciples)
                .FirstOrDefaultAsync(cell => cell.Id == request.CellId, cancellationToken);

            var disciples = cell?.Disciples ?? [];

            if (disciples.Count == 0)
                throw new ArgumentException("This cell doesn't have any disciples registered");

            var disciplesIds = disciples.Select(disciple => disciple.Id);

            var allValidDisciples = request.Attendees.All(disciplesIds.Contains);

            if (!allValidDisciples)
                throw new ArgumentException("Not all were valid disciples");

            var record = new CellAttendance
            {
                CellId = request.CellId,
                Attendees = [.. disciples.Where(disciple => request.Attendees.Contains(disciple.Id))],
                Date = DateTime.Now,
                Notes = request.Notes
            };

            dbContext.CellAttendances.Add(record);
            await dbContext.SaveChangesAsync(cancellationToken);

            return mapper.CellAttendanceToCellAttendanceDto(record);
        }
    }
}
