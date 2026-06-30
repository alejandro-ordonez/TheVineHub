using JMMinistry.Application.Features.DiscipleJourney.Enums;
using Mediator;
using SurrealDb.Net;
using SurrealDb.Net.Models.Response;
using System.Linq;
using SurrealDb.Net.Models;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.EnrollDisciples;

public class EnrollDisciplesHandler(ISurrealDbSession session)
    : ICommandHandler<EnrollDisciplesCommand>
{
    public async ValueTask<Unit> Handle(EnrollDisciplesCommand request, CancellationToken cancellationToken)
    {
        var cycleId = RecordId.From("cycle", request.CycleId);
        var leaderId = RecordId.From("user", request.LeaderId);

        var result = await session.Query(@$"
            {{
                LET $cycle = (SELECT * FROM {cycleId})[0];

                IF $cycle == NONE {{
                    THROW 'Cycle not found';
                }};

                IF !$cycle.is_open {{
                    THROW 'Cycle is not open for enrollment.';
                }};

                IF $cycle.enrollment_deadline != NONE AND $cycle.enrollment_deadline != NULL AND time::now() > $cycle.enrollment_deadline {{
                    THROW 'Enrollment deadline has passed.';
                }};

                LET $stepId = $cycle.disciple_step;
                -- Map Status to lowercase for schema compatibility
                LET $resolvedStatus = (
                    IF {request.InitialStatus?.ToString()} == 'InPrayers' THEN 'in_prayers'
                    ELSE IF {request.InitialStatus?.ToString()} == 'Enrolled' THEN 'enrolled'
                    ELSE IF {request.InitialStatus?.ToString()} == 'Completed' THEN 'completed'
                    ELSE 'enrolled' END
                );

                FOR $discipleId IN {request.DiscipleIds} {{
                    LET $user = type::record('user', $discipleId);

                    LET $alreadyEnrolled = count(SELECT * FROM completed WHERE in = $user AND out = $stepId AND status != 'Abandoned') > 0;
                    
                    IF !$alreadyEnrolled {{
                        -- Upsert completed relation
                        RELATE $user->completed->$stepId
                        SET
                            status = (IF {request.InitialStatus?.ToString()} != NULL THEN {request.InitialStatus?.ToString()} ELSE 'Enrolled' END),
                            leader = {leaderId},
                            date_created = time::now(),
                            last_updated = time::now();
 
                        -- Create enrolled relation (enrolled_to uses lowercase and date_created)
                        RELATE $user->enrolled_to->{cycleId}
                        SET
                            status = $resolvedStatus,
                            date_created = time::now(),
                            last_updated = time::now();
                    }};
                }};
            }}
        ", cancellationToken);

        if (result.HasErrors)
        {
            var error = result.Errors.First();
            if (error is SurrealDbErrorResult errorRes)
                throw new Exception($"SurrealDB Error: {errorRes.Details}");

            throw new Exception($"SurrealDB Error: {error}");
        }

        return Unit.Value;
    }
}
