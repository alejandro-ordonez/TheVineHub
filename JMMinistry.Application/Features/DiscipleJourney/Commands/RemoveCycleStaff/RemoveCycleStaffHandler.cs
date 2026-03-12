using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Services;
using JMMinistry.Domain.DiscipleJourney;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.RemoveCycleStaff;

public class RemoveCycleStaffHandler(IJmDbContext dbContext)
    : ICommandHandler<RemoveCycleStaffCommand>
{
    public async ValueTask<Unit> Handle(RemoveCycleStaffCommand request, CancellationToken cancellationToken)
    {
        var staff = await dbContext.CycleStaff
            .FirstOrDefaultAsync(s => s.Id == request.StaffId && s.StepCycleId == request.CycleId, cancellationToken)
            ?? throw new NotFoundException<CycleStaff>(request.StaffId.ToString());

        dbContext.CycleStaff.Remove(staff);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
