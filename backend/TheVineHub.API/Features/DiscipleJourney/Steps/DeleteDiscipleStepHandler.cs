using TheVineHub.API.Configuration.Exceptions;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace TheVineHub.API.Features.DiscipleJourney.Steps;

public class DeleteDiscipleStepHandler(ISurrealDbSession session)
    : ICommandHandler<DeleteDiscipleStepCommand>
{
    public async ValueTask<Unit> Handle(DeleteDiscipleStepCommand request, CancellationToken cancellationToken)
    {
        var stepId = request.StepId.StartsWith("disciple_step:") ? request.StepId : $"disciple_step:{request.StepId}";

        var result = await session.Query(@$"
            BEGIN TRANSACTION;

            -- Delete step
            DELETE type::record('disciple_step', {stepId});

            COMMIT TRANSACTION;
        ", cancellationToken);

        return Unit.Value;
    }
}
