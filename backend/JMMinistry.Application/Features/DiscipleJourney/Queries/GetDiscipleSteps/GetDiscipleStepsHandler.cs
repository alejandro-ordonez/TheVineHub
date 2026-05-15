using JMMinistry.Application.Mappers;
using JMMinistry.Common.Dtos.DiscipleJourney;
using JMMinistry.Domain.DiscipleJourney;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetDiscipleSteps;

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

        var steps = result.GetValue<List<DiscipleStep>>(0);

        return steps?.ToDto() ?? [];
    }
}
