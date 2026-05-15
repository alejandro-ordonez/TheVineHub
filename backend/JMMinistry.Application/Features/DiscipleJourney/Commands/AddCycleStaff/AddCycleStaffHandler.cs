using JMMinistry.Common.Dtos.DiscipleJourney;
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
            BEGIN TRANSACTION;
            
            LET $relation = (RELATE type::thing('user', {personId})->guides->type::thing('cycle', {cycleId}) 
            SET role = {request.Role.ToString()})[0];
            
            LET $user = (SELECT name, last_name FROM type::thing('user', {personId}))[0];
            
            COMMIT TRANSACTION;
            
            RETURN {{
                id: $relation.id,
                step_cycle_id: type::thing('cycle', {cycleId}),
                person_id: type::thing('user', {personId}),
                person_name: $user.name + ' ' + $user.last_name,
                role: $relation.role
            }};
        ", cancellationToken);

        return result.GetValue<CycleStaffDto>(0);
    }
}
