using JMMinistry.Application.Features.DiscipleJourney.Dtos;
using JMMinistry.Application.Features.DiscipleJourney.Commands.AssignGuide;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CompleteStepForDisciples;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CreateCycleSession;
using JMMinistry.Application.Features.DiscipleJourney.Commands.AddCycleStaff;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CreateDiscipleStep;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CreateStepCycle;
using JMMinistry.Application.Features.DiscipleJourney.Commands.EnrollDisciples;
using JMMinistry.Application.Features.DiscipleJourney.Commands.RecordCycleAttendance;
using JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateDiscipleStep;
using JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateEnrollmentStatus;
using JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateStepCompletion;
using JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateStepCycle;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.CreateCycleSession;

public class CreateCycleSessionHandler(ISurrealDbSession session)
    : ICommandHandler<CreateCycleSessionCommand, CycleSessionDto>
{
    public async ValueTask<CycleSessionDto> Handle(CreateCycleSessionCommand request, CancellationToken cancellationToken)
    {
        var cycleId = request.CycleId.StartsWith("cycle:") ? request.CycleId : $"cycle:{request.CycleId}";

        var result = await session.Query(@$"
            {{
                LET $session = (CREATE cycle_session SET
                    date = {request.Date.ToDateTime(TimeOnly.MinValue)},
                    topic = {request.Topic})[0];

                RELATE $session->session_of->type::record('cycle', {cycleId});

                RETURN {{
                    id: $session.id,
                    step_cycle_id: type::record('cycle', {cycleId}),
                    date: $session.date,
                    topic: $session.topic
                }};
            }}
        ", cancellationToken);

        return result.GetValue<CycleSessionDto>(0) ?? throw new Exception("Unexpected null from DB");
    }
}
