using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Services;
using JMMinistry.Domain.DiscipleJourney;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.RecordCycleAttendance;

public class RecordCycleAttendanceHandler(IJmDbContext dbContext)
    : ICommandHandler<RecordCycleAttendanceCommand>
{
    public async ValueTask<Unit> Handle(RecordCycleAttendanceCommand request, CancellationToken cancellationToken)
    {
        var sessionExists = await dbContext.CycleSessions
            .AnyAsync(s => s.Id == request.SessionId && s.StepCycleId == request.CycleId, cancellationToken);

        if (!sessionExists)
            throw new NotFoundException<CycleSession>(request.SessionId.ToString());

        // Remove existing attendances for this session (full replace)
        var existing = await dbContext.CycleAttendances
            .Where(a => a.CycleSessionId == request.SessionId)
            .ToListAsync(cancellationToken);

        dbContext.CycleAttendances.RemoveRange(existing);

        // Add new attendances
        var attendances = request.DiscipleIds.Select(discipleId => new CycleAttendance
        {
            CycleSessionId = request.SessionId,
            DiscipleId = discipleId
        });

        dbContext.CycleAttendances.AddRange(attendances);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
