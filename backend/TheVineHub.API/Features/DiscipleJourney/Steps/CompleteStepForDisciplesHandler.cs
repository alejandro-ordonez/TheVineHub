using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace TheVineHub.API.Features.DiscipleJourney.Steps;

public class CompleteStepForDisciplesHandler(ISurrealDbSession session)
    : ICommandHandler<CompleteStepForDisciplesCommand>
{
    public async ValueTask<Unit> Handle(CompleteStepForDisciplesCommand request, CancellationToken cancellationToken)
    {
        var stepId = request.StepId.StartsWith("disciple_step:") ? request.StepId : $"disciple_step:{request.StepId}";
        var leaderId = request.LeaderId.StartsWith("user:") ? request.LeaderId : $"user:{request.LeaderId}";

        var result = await session.Query(@$"
            {{
                LET $step = type::record('disciple_step', {stepId});
                LET $leader = type::record('user', {leaderId});

                FOR $doc IN {request.DiscipleDocuments} {{
                    LET $user = type::record('user', $doc);
                    RELATE $user->completed->$step
                    SET
                        status = 'InProgress',
                        leader = $leader,
                        date_created = {request.CompletionDate.ToDateTime(TimeOnly.MinValue)},
                        last_updated = {request.CompletionDate.ToDateTime(TimeOnly.MinValue)};
                }};
            }}
        ", cancellationToken);

        return Unit.Value;
    }
}
