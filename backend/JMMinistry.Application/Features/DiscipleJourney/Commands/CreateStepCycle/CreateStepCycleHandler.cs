using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.CreateStepCycle;

public class CreateStepCycleHandler(ISurrealDbSession session)
    : ICommandHandler<CreateStepCycleCommand, StepCycleDto>
{
    public async ValueTask<StepCycleDto> Handle(CreateStepCycleCommand request, CancellationToken cancellationToken)
    {
        var stepId = request.StepId.StartsWith("disciple_step:") ? request.StepId : $"disciple_step:{request.StepId}";

        var result = await session.Query(@$"
            BEGIN TRANSACTION;
            
            LET $cycle = (CREATE cycle SET 
                name = {request.Name}, 
                start_date = {request.StartDate.ToDateTime(TimeOnly.MinValue)}, 
                end_date = {request.EndDate.ToDateTime(TimeOnly.MinValue)}, 
                min_attendance = {request.MinAttendanceRequired}, 
                enrollment_deadline = {request.EnrollmentDeadline?.ToDateTime(TimeOnly.MinValue)}, 
                is_open = true)[0];
            
            RELATE type::thing('disciple_step', {stepId})->has->$cycle.id;
            
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
                session_count: 0,
                enrolled_count: 0
            }};
        ", cancellationToken);

        return result.GetValue<StepCycleDto>(0);
    }
}
