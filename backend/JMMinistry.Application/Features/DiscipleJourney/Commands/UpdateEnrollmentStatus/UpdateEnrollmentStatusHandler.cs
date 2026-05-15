using JMMinistry.Application.Exceptions;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateEnrollmentStatus;

public class UpdateEnrollmentStatusHandler(ISurrealDbSession session)
    : ICommandHandler<UpdateEnrollmentStatusCommand>
{
    public async ValueTask<Unit> Handle(UpdateEnrollmentStatusCommand request, CancellationToken cancellationToken)
    {
        var enrollmentId = request.EnrollmentId.StartsWith("enrolled:") ? request.EnrollmentId : $"enrolled:{request.EnrollmentId}";
        var cycleId = request.CycleId.StartsWith("cycle:") ? request.CycleId : $"cycle:{request.CycleId}";

        var result = await session.Query(@$"
            -- Find the user and the step associated with this enrollment
            LET $enrollment = (SELECT in, out FROM type::thing('enrolled', {enrollmentId}) WHERE out = type::thing('cycle', {cycleId}))[0];
            
            IF $enrollment == NONE THEN
                THROW 'Enrollment not found';
            END;

            LET $user = $enrollment.in;
            LET $stepId = (SELECT VALUE in FROM <-has WHERE out = type::thing('cycle', {cycleId}))[0];

            IF $stepId == NONE THEN
                THROW 'Step associated with cycle not found';
            END;

            BEGIN TRANSACTION;
            
            -- Update the completed relation status
            UPDATE completed SET 
                status = {request.Status.ToString()},
                last_updated = time::now()
            WHERE in = $user AND out = $stepId;
            
            COMMIT TRANSACTION;
        ", cancellationToken);

        return Unit.Value;
    }
}
