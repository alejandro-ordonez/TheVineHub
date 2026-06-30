using JMMinistry.Application.Features.DiscipleJourney.Dtos;
using JMMinistry.Application.Features.DiscipleJourney.Commands.AssignGuide;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CompleteStepForDisciples;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CreateCycleSession;
using JMMinistry.Application.Features.DiscipleJourney.Commands.AddCycleStaff;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CreateDiscipleStep;
using JMMinistry.Application.Features.DiscipleJourney.Commands.CreateStepCycle;
using JMMinistry.Application.Features.DiscipleJourney.Commands.EnrollDisciples;
using JMMinistry.Application.Features.DiscipleJourney.Commands.RecordCycleAttendance;
using JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateDiscipleStep;
using JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateEnrollmentStatus;
using JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateStepCompletion;
using JMMinistry.Application.Features.DiscipleJourney.Commands.UpdateStepCycle;

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

        var steps = result.GetValue<List<DiscipleStepDto>>(0);

        return steps ?? [];
    }
}
