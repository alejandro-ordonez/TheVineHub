using JMMinistry.Application.Exceptions;
using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateStepCycle;

public class UpdateStepCycleHandler(ISurrealDbSession session)
    : ICommandHandler<UpdateStepCycleCommand, StepCycleDto>
{
    public async ValueTask<StepCycleDto> Handle(UpdateStepCycleCommand request, CancellationToken cancellationToken)
    {
        var cycleId = request.CycleId.StartsWith("cycle:") ? request.CycleId : $"cycle:{request.CycleId}";
        var stepId = request.StepId.StartsWith("disciple_step:") ? request.StepId : $"disciple_step:{request.StepId}";

        var result = await session.Query(@$"
            -- Verify cycle belongs to step
            LET $belongs = (SELECT count() > 0 FROM has WHERE in = type::thing('disciple_step', {stepId}) AND out = type::thing('cycle', {cycleId}))[0];
            
            IF !$belongs THEN
                THROW 'Cycle ' + {cycleId} + ' does not belong to step ' + {stepId};
            END;

            BEGIN TRANSACTION;
            
            LET $cycle = (UPDATE type::thing('cycle', {cycleId}) SET 
                name = {request.Name}, 
                start_date = {request.StartDate.ToDateTime(TimeOnly.MinValue)}, 
                end_date = {request.EndDate.ToDateTime(TimeOnly.MinValue)}, 
                min_attendance = {request.MinAttendanceRequired}, 
                is_open = {request.IsOpen}, 
                enrollment_deadline = {request.EnrollmentDeadline?.ToDateTime(TimeOnly.MinValue)})[0];

            LET $sessionCount = (SELECT count() FROM session_of WHERE out = type::thing('cycle', {cycleId}))[0].count;
            LET $enrolledCount = (SELECT count() FROM enrolled WHERE out = type::thing('cycle', {cycleId}))[0].count;
            
            COMMIT TRANSACTION;
            
            RETURN {{
                id: $cycle.id,
                disciple_step_id: type::thing('disciple_step', {stepId}),
                name: $cycle.name,
                start_date: $cycle.start_date,
                end_date: $cycle.end_date,
                min_attendance_required: $cycle.min_attendance,
                is_open: $cycle.is_open,
                enrollment_deadline: $cycle.enrollment_deadline,
                session_count: $sessionCount,
                enrolled_count: $enrolledCount
            }};
        ", cancellationToken);

        return result.GetValue<StepCycleDto>(0);
    }
}
