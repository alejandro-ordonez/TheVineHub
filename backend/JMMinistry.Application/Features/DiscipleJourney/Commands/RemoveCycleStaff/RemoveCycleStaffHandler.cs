using JMMinistry.Application.Exceptions;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.DiscipleJourney.Commands.RemoveCycleStaff;

public class RemoveCycleStaffHandler(ISurrealDbSession session)
    : ICommandHandler<RemoveCycleStaffCommand>
{
    public async ValueTask<Unit> Handle(RemoveCycleStaffCommand request, CancellationToken cancellationToken)
    {
        var cycleId = request.CycleId.StartsWith("cycle:") ? request.CycleId : $"cycle:{request.CycleId}";
        var staffId = request.StaffId.StartsWith("guides:") ? request.StaffId : $"guides:{request.StaffId}";

        var result = await session.Query(@$"
            BEGIN TRANSACTION;

            -- Delete the guide relationship
            DELETE type::record('guides', {staffId});

            COMMIT TRANSACTION;
        ", cancellationToken);

        return Unit.Value;
    }
}
