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

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.AddCycleStaff;

public class AddCycleStaffHandler(ISurrealDbSession session)
    : ICommandHandler<AddCycleStaffCommand, CycleStaffDto>
{
    public async ValueTask<CycleStaffDto> Handle(AddCycleStaffCommand request, CancellationToken cancellationToken)
    {
        var cycleId = request.CycleId.StartsWith("cycle:") ? request.CycleId : $"cycle:{request.CycleId}";
        var personId = request.PersonId.StartsWith("user:") ? request.PersonId : $"user:{request.PersonId}";

        var result = await session.Query(@$"
            {{
                LET $relation = (RELATE type::record('user', {personId})->guides->type::record('cycle', {cycleId})
                SET role = {request.Role.ToString()})[0];

                LET $user = (SELECT name, last_name FROM type::record('user', {personId}))[0];

                RETURN {{
                    id: $relation.id,
                    step_cycle_id: type::record('cycle', {cycleId}),
                    person_id: type::record('user', {personId}),
                    person_name: $user.name + ' ' + $user.last_name,
                    role: $relation.role
                }};
            }}
        ", cancellationToken);

        return result.GetValue<CycleStaffDto>(0) ?? throw new Exception("Unexpected null from DB");
    }
}
