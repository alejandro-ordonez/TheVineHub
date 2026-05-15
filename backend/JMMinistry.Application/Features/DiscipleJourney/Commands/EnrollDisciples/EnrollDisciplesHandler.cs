using JMMinistry.Application.Exceptions;
using JMMinistry.Common.Dtos.DiscipleJourney.Enums;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.EnrollDisciples;

public class EnrollDisciplesHandler(ISurrealDbSession session)
    : ICommandHandler<EnrollDisciplesCommand>
{
    public async ValueTask<Unit> Handle(EnrollDisciplesCommand request, CancellationToken cancellationToken)
    {
        var cycleId = request.CycleId.StartsWith("cycle:") ? request.CycleId : $"cycle:{request.CycleId}";
        var leaderId = request.LeaderId.StartsWith("user:") ? request.LeaderId : $"user:{request.LeaderId}";

        var result = await session.Query(@$"
            LET $cycle = (SELECT *, (SELECT VALUE in FROM <-has)[0] AS step_id FROM type::thing('cycle', {cycleId}))[0];
            
            IF $cycle == NONE THEN
                THROW 'Cycle not found';
            END;

            IF !$cycle.is_open THEN
                THROW 'Cycle is not open for enrollment.';
            END;

            IF $cycle.enrollment_deadline != NONE AND time::now() > $cycle.enrollment_deadline THEN
                THROW 'Enrollment deadline has passed.';
            END;

            LET $stepId = $cycle.step_id;
            LET $resolvedStatus = IF $cycle.is_open THEN {request.InitialStatus?.ToString()} OR 'Enrolled' ELSE 'Completed' END;

            BEGIN TRANSACTION;
            
            FOR $discipleId IN {request.DiscipleIds} {{
                LET $user = type::thing('user', $discipleId);
                
                -- Check if already enrolled in this step with non-abandoned status
                LET $alreadyEnrolled = (SELECT count() > 0 FROM completed WHERE in = $user AND out = $stepId AND status != 'Abandoned')[0];
                
                IF !$alreadyEnrolled THEN
                    -- Upsert completed relation (StepCompletion)
                    RELATE $user->completed->$stepId 
                    SET 
                        status = $resolvedStatus,
                        leader = type::thing('user', {leaderId}),
                        date_created = time::now(),
                        last_updated = time::now();

                    -- Create enrolled relation (CycleEnrollment)
                    RELATE $user->enrolled->type::thing('cycle', {cycleId})
                    SET
                        enrolled_at = time::now();
                END;
            }};
            
            COMMIT TRANSACTION;
        ", cancellationToken);

        return Unit.Value;
    }
}
