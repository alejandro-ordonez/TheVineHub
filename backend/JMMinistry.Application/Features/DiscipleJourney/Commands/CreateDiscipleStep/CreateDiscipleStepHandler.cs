using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.CreateDiscipleStep;

public class CreateDiscipleStepHandler(ISurrealDbSession session)
    : ICommandHandler<CreateDiscipleStepCommand, DiscipleStepDto>
{
    public async ValueTask<DiscipleStepDto> Handle(CreateDiscipleStepCommand request, CancellationToken cancellationToken)
    {
        var result = await session.Query(@$"
            BEGIN TRANSACTION;
            
            LET $step = (CREATE disciple_step SET 
                name = {request.Name}, 
                description = {request.Description}, 
                category = {request.StepCategory.ToString()}, 
                requires_cycle = {request.RequiresCycle}, 
                requires_admin_approval = {request.RequiresAdminApproval})[0];

            IF {request.ParentStepId} != NONE THEN
                -- Link to parent (assuming a child_of or sub_step_of relation)
                -- Let's use 'requires' or similar if it's a hierarchy, or just a field.
                -- Actually, based on legacy, it's ParentStepId.
                UPDATE $step.id SET parent_step = type::thing('disciple_step', {request.ParentStepId});
            END;

            FOR $reqId IN {request.RequirementIds} {{
                RELATE $step.id->requires->type::thing('disciple_step', $reqId);
            }};
            
            COMMIT TRANSACTION;
            
            RETURN $step;
        ", cancellationToken);

        return result.GetValue<DiscipleStepDto>(0);
    }
}
