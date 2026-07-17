using TheVineHub.API.Features.Users;
using TheVineHub.API.Configuration.Exceptions;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace TheVineHub.API.Features.Users.MarryLeaders;

public class MarryLeadersHandler(ISurrealDbSession session)
    : ICommandHandler<MarryLeadersCommand>
{
    public async ValueTask<Unit> Handle(MarryLeadersCommand request, CancellationToken cancellationToken)
    {
        var personId = $"user:{request.PersonId}";
        var spouseId = $"user:{request.SpouseId}";
        var requestorId = $"user:{request.RequestorId}";

        // Verify requestor is a leader of both persons (recursive)
        var result = await session.Query(@$"
            LET $person = type::record('user', {request.PersonId});
            LET $spouse = type::record('user', {request.SpouseId});
            LET $requestor = type::record('user', {request.RequestorId});

            IF !fn::is_leader($requestor, $person) OR !fn::is_leader($requestor, $spouse) THEN
                THROW 'You must be a cell leader of both persons to perform this action.';
            END;

            fn::marry_users($person, $spouse);
        ", cancellationToken);

        return Unit.Value;
    }
}
