using TheVineHub.API.Features.DiscipleJourney;
using Mediator;
using SurrealDb.Net;
using SurrealDb.Net.Models.Response;
using System.Linq;
using SurrealDb.Net.Models;

namespace TheVineHub.API.Features.DiscipleJourney.Enrollments;

public class EnrollDisciplesHandler(ISurrealDbSession session)
    : ICommandHandler<EnrollDisciplesCommand>
{
    public async ValueTask<Unit> Handle(EnrollDisciplesCommand request, CancellationToken cancellationToken)
    {
        var cycleId = RecordId.From("cycle", request.CycleId);
        var leaderId = RecordId.From("user", request.LeaderId);
        // Compute status strings in C# so the SDK can parameterize them properly
        var completedStatus = request.InitialStatus?.ToString() ?? "InProgress";
        var enrolledStatus = request.InitialStatus switch
        {
            StepStatus.InPrayers => "in_prayers",
            StepStatus.Enrolled  => "enrolled",
            StepStatus.Completed => "completed",
            _                    => "enrolled"
        };

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
                FOR $discipleId IN {request.DiscipleIds} {{
                    LET $user = type::record('user', $discipleId);

                    LET $alreadyEnrolled = count(SELECT * FROM completed WHERE in = $user AND out = $stepId AND status != 'Abandoned') > 0;

                    IF !$alreadyEnrolled {{
                        -- Upsert completed relation
                        RELATE $user->completed->$stepId
                        SET
                            status = {completedStatus},
                            leader = {leaderId},
                            date_created = time::now(),
                            last_updated = time::now();
 
                        -- Create enrolled relation (enrolled uses lowercase and date_created)
                        RELATE $user->enrolled->{cycleId}
                        SET
                            status = {enrolledStatus},
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
                throw new TheVineHub.API.Configuration.Exceptions.DatabaseExecutionException($"SurrealDB Error: {errorRes.Details}");

            throw new TheVineHub.API.Configuration.Exceptions.DatabaseExecutionException($"SurrealDB Error: {error}");
        }

        return Unit.Value;
    }
}
