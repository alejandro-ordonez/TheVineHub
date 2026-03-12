using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.DiscipleJourney;
using JMMinistry.Common.Dtos.DiscipleJourney.Enums;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.DiscipleJourney.Queries.GetCycleStaff;

public class GetCycleStaffHandler(IJmDbContext dbContext)
    : IQueryHandler<GetCycleStaffQuery, IList<CycleStaffDto>>
{
    public async ValueTask<IList<CycleStaffDto>> Handle(GetCycleStaffQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.CycleStaff
            .Where(s => s.StepCycleId == request.CycleId)
            .Include(s => s.Person)
            .OrderBy(s => s.Role)
            .ThenBy(s => s.Person!.Name)
            .Select(s => new CycleStaffDto
            {
                Id = s.Id,
                StepCycleId = s.StepCycleId,
                PersonId = s.PersonId,
                PersonName = s.Person!.Name + " " + s.Person.LastName,
                Role = (CycleStaffRole)s.Role
            })
            .ToListAsync(cancellationToken);
    }
}
