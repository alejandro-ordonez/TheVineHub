using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.DiscipleJourney;
using JMMinistry.Domain.DiscipleJourney;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.AddCycleStaff;

public class AddCycleStaffHandler(IJmDbContext dbContext)
    : ICommandHandler<AddCycleStaffCommand, CycleStaffDto>
{
    public async ValueTask<CycleStaffDto> Handle(AddCycleStaffCommand request, CancellationToken cancellationToken)
    {
        var staff = new CycleStaff
        {
            StepCycleId = request.CycleId,
            PersonId = request.PersonId,
            Role = (CycleStaffRole)(int)request.Role
        };

        dbContext.CycleStaff.Add(staff);
        await dbContext.SaveChangesAsync(cancellationToken);

        var person = await dbContext.PersonalInfo
            .Where(p => p.Id == request.PersonId)
            .Select(p => p.Name + " " + p.LastName)
            .FirstOrDefaultAsync(cancellationToken);

        return new CycleStaffDto
        {
            Id = staff.Id,
            StepCycleId = staff.StepCycleId,
            PersonId = staff.PersonId,
            PersonName = person ?? string.Empty,
            Role = request.Role
        };
    }
}
