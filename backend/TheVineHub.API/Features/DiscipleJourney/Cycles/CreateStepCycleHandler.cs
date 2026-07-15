using TheVineHub.API.Features.DiscipleJourney;
using Mediator;
using SurrealDb.Net;
using SurrealDb.Net.Models.Response;
using System.Linq;
using SurrealDb.Net.Models;

namespace TheVineHub.API.Features.DiscipleJourney.Cycles;

public class CreateStepCycleHandler(ISurrealDbSession session)
    : ICommandHandler<CreateStepCycleCommand, StepCycleDto>
{
    public async ValueTask<StepCycleDto> Handle(CreateStepCycleCommand request, CancellationToken cancellationToken)
    {
        var stepId = RecordId.From("disciple_step", request.StepId);

        var result = await session.Query(@$"
            {{
                LET $step = {stepId};
                LET $cycle = (CREATE cycle SET
                    name = {request.Name},
                    start_date = {request.StartDate.ToDateTime(TimeOnly.MinValue)},
                    end_date = {request.EndDate.ToDateTime(TimeOnly.MinValue)},
                    min_attendance = {request.MinAttendanceRequired},
                    enrollment_deadline = {request.EnrollmentDeadline?.ToDateTime(TimeOnly.MinValue)} OR NONE,
                    disciple_step = $step,
                    is_open = true)[0];

                RELATE $step->has->$cycle;

                RETURN {{
                    id: $cycle.id,
                    disciple_step_id: $step,
                    name: $cycle.name,
                    start_date: $cycle.start_date,
                    end_date: $cycle.end_date,
                    min_attendance_required: $cycle.min_attendance,
                    is_open: $cycle.is_open,
                    enrollment_deadline: $cycle.enrollment_deadline,
                    session_count: 0,
                    enrolled_count: 0
                }};
            }}
        ", cancellationToken);

        if (result.HasErrors)
        {
            var error = result.Errors.First();
            if (error is SurrealDbErrorResult errorRes)
                throw new Exception($"SurrealDB Error: {errorRes.Details}");

            throw new Exception($"SurrealDB Error: {error}");
        }

        return result.GetValue<StepCycleDto>(0) ?? throw new Exception("Unexpected null from DB");
    }
}
