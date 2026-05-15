using JMMinistry.Application.Exceptions;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.AssignGuide;

public class AssignGuideHandler(ISurrealDbSession session)
    : ICommandHandler<AssignGuideCommand>
{
    public async ValueTask<Unit> Handle(AssignGuideCommand request, CancellationToken cancellationToken)
    {
        var cycleId = request.CycleId.StartsWith("cycle:") ? request.CycleId : $"cycle:{request.CycleId}";
        var staffId = request.CycleStaffId.StartsWith("user:") ? request.CycleStaffId : $"user:{request.CycleStaffId}";

        var result = await session.Query(@$"
            -- Verify staff is a guide for this cycle
            LET $is_guide = (SELECT count() > 0 FROM guides WHERE in = type::thing('user', {staffId}) AND out = type::thing('cycle', {cycleId}))[0];
            
            IF !$is_guide THEN
                THROW 'User ' + {staffId} + ' is not a guide for cycle ' + {cycleId};
            END;

            BEGIN TRANSACTION;
            
            FOR $enrollmentId IN {request.EnrollmentIds} {{
                UPDATE type::thing('enrolled', $enrollmentId) SET guide = type::thing('user', {staffId});
            }};
            
            COMMIT TRANSACTION;
        ", cancellationToken);

        return Unit.Value;
    }
}
