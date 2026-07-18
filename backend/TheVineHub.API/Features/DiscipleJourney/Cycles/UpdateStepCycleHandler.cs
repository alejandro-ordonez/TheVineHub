using TheVineHub.API.Configuration.Exceptions;
using TheVineHub.API.Features.DiscipleJourney;
using Mediator;
using SurrealDb.Net;
using SurrealDb.Net.Models.Response;
using System.Linq;
using SurrealDb.Net.Models;

namespace TheVineHub.API.Features.DiscipleJourney.Cycles;

public class UpdateStepCycleHandler(ISurrealDbSession session)
    : ICommandHandler<UpdateStepCycleCommand, StepCycleDto>
{
    public async ValueTask<StepCycleDto> Handle(UpdateStepCycleCommand request, CancellationToken cancellationToken)
    {
        var cycleId = RecordId.From("cycle", request.CycleId);
        var stepId = RecordId.From("disciple_step", request.StepId);

        var result = await session.Query(@$"
            {{
                -- Verify cycle belongs to step
                LET $belongs = (SELECT count() > 0 FROM has WHERE in = {stepId} AND out = {cycleId})[0];

                IF !$belongs THEN
                    THROW 'Cycle ' + {request.CycleId} + ' does not belong to step ' + {request.StepId};
                END;

                LET $cycle = (UPDATE {cycleId} SET
                    name = {request.Name},
                    start_date = {request.StartDate.ToDateTime(TimeOnly.MinValue)},
                    end_date = {request.EndDate.ToDateTime(TimeOnly.MinValue)},
                    min_attendance = {request.MinAttendanceRequired},
                    is_open = {request.IsOpen},
                    enrollment_deadline = {request.EnrollmentDeadline?.ToDateTime(TimeOnly.MinValue)} OR NONE,
                    disciple_step = {stepId})[0];

                LET $sessionCount = (SELECT count() FROM cycle_session WHERE cycle = {cycleId})[0].count;
                LET $enrolledCount = (SELECT count() FROM enrolled WHERE out = {cycleId})[0].count;

                RETURN {{
                    id: $cycle.id,
                    disciple_step_id: {stepId},
                    name: $cycle.name,
                    start_date: $cycle.start_date,
                    end_date: $cycle.end_date,
                    min_attendance_required: $cycle.min_attendance,
                    is_open: $cycle.is_open,
                    enrollment_deadline: $cycle.enrollment_deadline,
                    session_count: $sessionCount,
                    enrolled_count: $enrolledCount
                }};
            }}
        ", cancellationToken);

        if (result.HasErrors)
        {
            throw new TheVineHub.API.Configuration.Exceptions.DatabaseExecutionException($"SurrealDB Error: {result.Errors.First()}");
        }

        return result.GetValue<StepCycleDto>(0) ?? throw new Exception("Unexpected null from DB");
    }
}
