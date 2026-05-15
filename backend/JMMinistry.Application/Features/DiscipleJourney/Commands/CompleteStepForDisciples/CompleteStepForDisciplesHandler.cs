using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.CompleteStepForDisciples;

public class CompleteStepForDisciplesHandler(ISurrealDbSession session)
    : ICommandHandler<CompleteStepForDisciplesCommand>
{
    public async ValueTask<Unit> Handle(CompleteStepForDisciplesCommand request, CancellationToken cancellationToken)
    {
        var stepId = request.StepId.StartsWith("disciple_step:") ? request.StepId : $"disciple_step:{request.StepId}";
        var leaderId = request.LeaderId.StartsWith("user:") ? request.LeaderId : $"user:{request.LeaderId}";

        var result = await session.Query(@$"
            BEGIN TRANSACTION;
            
            FOR $doc IN {request.DiscipleDocuments} {{
                LET $user = type::thing('user', $doc);
                RELATE $user->completed->type::thing('disciple_step', {stepId}) 
                SET 
                    status = 'InProgress',
                    leader = type::thing('user', {leaderId}),
                    date_created = {request.CompletionDate.ToDateTime(TimeOnly.MinValue)},
                    last_updated = {request.CompletionDate.ToDateTime(TimeOnly.MinValue)};
            }};
            
            COMMIT TRANSACTION;
        ", cancellationToken);

        return Unit.Value;
    }
}
