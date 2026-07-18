using TheVineHub.API.Configuration.Exceptions;
using TheVineHub.API.Features.DiscipleJourney;
using Mediator;
using SurrealDb.Net;
using SurrealDb.Net.Models;
using SurrealDb.Net.Models.Response;
using System.Linq;

namespace TheVineHub.API.Features.DiscipleJourney.Enrollments;

public class UpdateEnrollmentStatusHandler(ISurrealDbSession session)
    : ICommandHandler<UpdateEnrollmentStatusCommand>
{
    public async ValueTask<Unit> Handle(UpdateEnrollmentStatusCommand request, CancellationToken cancellationToken)
    {
        // Build typed RecordIds so the SDK parameterizes them correctly
        var enrollmentIdStr = request.EnrollmentId.StartsWith("enrolled:") ? request.EnrollmentId : $"enrolled:{request.EnrollmentId}";
        var cycleIdStr      = request.CycleId.StartsWith("cycle:")      ? request.CycleId      : $"cycle:{request.CycleId}";

        var enrolledRecordId = RecordId.From("enrolled", enrollmentIdStr.Split(':', 2)[1]);
        var cycleRecordId    = RecordId.From("cycle",    cycleIdStr.Split(':', 2)[1]);

        // Pre-compute status string so SDK can safely parameterize it
        var statusStr = request.Status.ToString();

        var result = await session.Query(@$"
            -- Find the user and the step associated with this enrollment
            LET $enrollment = (SELECT in, out FROM {enrolledRecordId} WHERE out = {cycleRecordId})[0];

            IF $enrollment == NONE THEN
                THROW 'Enrollment not found';
            END;

            LET $user   = $enrollment.in;
            LET $stepId = (SELECT VALUE in FROM {cycleRecordId}<-has)[0];

            IF $stepId == NONE THEN
                THROW 'Step associated with cycle not found';
            END;

            -- Update the completed relation status
            UPDATE completed SET
                status       = {statusStr},
                last_updated = time::now()
            WHERE in = $user AND out = $stepId;
        ", cancellationToken);

        if (result.HasErrors)
        {
            var error = result.Errors.First();
            if (error is SurrealDbErrorResult errorRes)
                throw new TheVineHub.API.Configuration.Exceptions.DatabaseExecutionException($"SurrealDB Error: {errorRes.Details}");
            throw new TheVineHub.API.Configuration.Exceptions.DatabaseExecutionException($"SurrealDB Error: {error}");
        }

        return Unit.Value;
    }
}
