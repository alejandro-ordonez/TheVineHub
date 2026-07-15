using TheVineHub.API.Features.DiscipleJourney;
using Mediator;
using SurrealDb.Net;
using SurrealDb.Net.Models.Response;
using System.Linq;
using SurrealDb.Net.Models;

namespace TheVineHub.API.Features.DiscipleJourney.Steps;

public class UpdateDiscipleStepHandler(ISurrealDbSession session)
    : ICommandHandler<UpdateDiscipleStepCommand, DiscipleStepDto>
{
    public async ValueTask<DiscipleStepDto> Handle(UpdateDiscipleStepCommand request, CancellationToken cancellationToken)
    {
        var result = await session.Query(@$"
            {{
                LET $step = (UPDATE {request.Id} SET
                    name = {request.Name},
                    description = {request.Description},
                    category = {request.StepCategory.ToString()},
                    requires_cycle = {request.RequiresCycle},
                    requires_admin_approval = {request.RequiresAdminApproval},
                    parent_step = (IF {request.ParentStepId} != NONE AND {request.ParentStepId} != NULL THEN type::record('disciple_step', {request.ParentStepId}) ELSE NONE END))[0];

                IF $step == NONE THEN
                    THROW 'Disciple step not found';
                END;

                -- Update requirements
                DELETE requires WHERE in = {request.Id};

                FOR $reqId IN {request.RequirementIds} {{
                    LET $req = type::record('disciple_step', $reqId);
                    RELATE {request.Id}->requires->$req;
                }};

                RETURN $step;
            }}
        ", cancellationToken);

        if (result.HasErrors)
        {
            var error = result.Errors.First();
            if (error is SurrealDbErrorResult errorRes)
                throw new Exception($"SurrealDB Error: {errorRes.Details}");

            throw new Exception($"SurrealDB Error: {error}");
        }

        return result.GetValue<DiscipleStepDto>(0) ?? throw new Exception("Unexpected null from DB");
    }
}
