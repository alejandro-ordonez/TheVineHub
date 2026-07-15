using TheVineHub.API.Configuration.Exceptions;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace TheVineHub.API.Features.DiscipleJourney.Steps;

public class UpdateStepCompletionHandler(ISurrealDbSession session)
    : ICommandHandler<UpdateStepCompletionCommand>
{
    public async ValueTask<Unit> Handle(UpdateStepCompletionCommand request, CancellationToken cancellationToken)
    {
        var stepId = request.StepId.StartsWith("disciple_step:") ? request.StepId : $"disciple_step:{request.StepId}";
        var userId = request.DiscipleId.StartsWith("user:") ? request.DiscipleId : $"user:{request.DiscipleId}";

        var result = await session.Query(@$"
            BEGIN TRANSACTION;

            UPDATE completed SET
                status = {request.StepStatus.ToString()},
                last_updated = {(request.CompletionDate ?? DateOnly.FromDateTime(DateTime.UtcNow)).ToDateTime(TimeOnly.MinValue)}
            WHERE in = type::record('user', {request.DiscipleId}) AND out = type::record('disciple_step', {request.StepId});

            IF array::len((SELECT * FROM completed WHERE in = type::record('user', {request.DiscipleId}) AND out = type::record('disciple_step', {request.StepId}))) == 0 THEN
                THROW 'StepCompletion not found';
            END;

            COMMIT TRANSACTION;
        ", cancellationToken);

        return Unit.Value;
    }
}
