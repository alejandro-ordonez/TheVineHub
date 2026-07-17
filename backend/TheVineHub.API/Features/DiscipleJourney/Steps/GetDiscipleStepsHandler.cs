using TheVineHub.API.Features.DiscipleJourney;
using TheVineHub.API.Features.DiscipleJourney.Enrollments;
using TheVineHub.API.Features.DiscipleJourney.Steps;
using TheVineHub.API.Features.DiscipleJourney.Sessions;
using TheVineHub.API.Features.DiscipleJourney.Staff;
using TheVineHub.API.Features.DiscipleJourney.Steps;
using TheVineHub.API.Features.DiscipleJourney.Cycles;
using TheVineHub.API.Features.DiscipleJourney.Enrollments;
using TheVineHub.API.Features.DiscipleJourney.Attendance;
using TheVineHub.API.Features.DiscipleJourney.Steps;
using TheVineHub.API.Features.DiscipleJourney.Enrollments;
using TheVineHub.API.Features.DiscipleJourney.Steps;
using TheVineHub.API.Features.DiscipleJourney.Cycles;

using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace TheVineHub.API.Features.DiscipleJourney.Steps;

public class GetDiscipleStepsHandler(ISurrealDbSession session)
    : IQueryHandler<GetDiscipleStepsQuery, IEnumerable<DiscipleStepDto>>
{
    public async ValueTask<IEnumerable<DiscipleStepDto>> Handle(GetDiscipleStepsQuery request, CancellationToken cancellationToken)
    {
        var result = await session.Query(@$"
            SELECT 
                *,
                ->requires.out AS requirement_ids,
                (
                    SELECT 
                        *, 
                        ->requires.out AS requirement_ids 
                    FROM disciple_step 
                    WHERE parent_step = $parent.id
                ) AS sub_steps
            FROM disciple_step 
            WHERE parent_step = NONE
            ORDER BY category ASC;
        ", cancellationToken);

        var steps = result.GetValue<List<DiscipleStepDto>>(0);

        return steps ?? [];
    }
}
