using FluentValidation;
using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Features.Cells.Queries.CellCheckIsAuthorized;
using JMMinistry.Application.Services;
using JMMinistry.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Cells.Commands.RecordAttendance
{
    public class RecordAttendanceHandler(IJmDbContext dbContext, IMediator mediator) : IRequestHandler<RecordAttendanceCommand>
    {
        public async Task Handle(RecordAttendanceCommand request, CancellationToken cancellationToken)
        {
            var checkCommand = new CellCheckIsAuthorizedQuery { CellId = request.CellId, RequestorId = request.RequestorId };
            var isAuthorized = await mediator.Send(checkCommand, cancellationToken);

            if (!isAuthorized)
                throw new NotAuthorizedException();

            var disciplesIds = await dbContext.Cells
                .Include(cell => cell.Disciples)
                .Where(cell => cell.Id == request.CellId)
                .SelectMany(cell => cell.Disciples)
                .Select(disciples => disciples.Id)
                .ToListAsync(cancellationToken);

            var allValidDisciples = request.Attendees.All(disciplesIds.Contains);

            if (!allValidDisciples)
                throw new ArgumentException("Not all were valid disciples");

            var record = new CellAttendance
            {
                CellId = request.CellId,
                Attendees = [.. request.Attendees.Select(document => new PersonalInfo { Id = document })]
            };

            dbContext.CellAttendances.Add(record);
            await dbContext.SaveChangesAsync();
        }
    }
}
