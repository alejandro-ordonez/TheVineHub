using JMMinistry.Application.Exceptions;
using JMMinistry.Common.Dtos.DiscipleJourney;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateDiscipleStep;

public class UpdateDiscipleStepHandler(ISurrealDbSession session)
    : ICommandHandler<UpdateDiscipleStepCommand, DiscipleStepDto>
{
    public async ValueTask<DiscipleStepDto> Handle(UpdateDiscipleStepCommand request, CancellationToken cancellationToken)
    {
        var stepId = request.Id.StartsWith("disciple_step:") ? request.Id : $"disciple_step:{request.Id}";

        var result = await session.Query(@$"
            BEGIN TRANSACTION;
            
            LET $step = (UPDATE type::thing('disciple_step', {request.Id}) SET 
                name = {request.Name}, 
                description = {request.Description}, 
                category = {request.StepCategory.ToString()}, 
                requires_cycle = {request.RequiresCycle}, 
                requires_admin_approval = {request.RequiresAdminApproval},
                parent_step = type::thing('disciple_step', {request.ParentStepId}))[0];

            IF $step == NONE THEN
                THROW 'Disciple step not found';
            END;

            -- Update requirements
            DELETE requires WHERE in = type::thing('disciple_step', {request.Id});
            
            FOR $reqId IN {request.RequirementIds} {{
                RELATE type::thing('disciple_step', {request.Id})->requires->type::thing('disciple_step', $reqId);
            }};
            
            COMMIT TRANSACTION;
            
            RETURN $step;
        ", cancellationToken);

        return result.GetValue<DiscipleStepDto>(0);
    }
}
