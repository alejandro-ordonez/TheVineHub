using TheVineHub.API.Configuration.Exceptions;
using TheVineHub.API.Common;
using TheVineHub.API.Features.Users;
using TheVineHub.API.Configuration.Exceptions;
using Mediator;
using SurrealDb.Net;
using SurrealDb.Net.Models.Response;
using System.Linq;
using SurrealDb.Net.Models;

namespace TheVineHub.API.Features.Users.GetUserInfo
{
    public class GetUserInfoHandler(ISurrealDbSession session)
        : IQueryHandler<GetUserInfoQuery, GetUserInfoResponse>
    {
        public async ValueTask<GetUserInfoResponse> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            var userId = RecordId.From("user", request.Document);
            var requestorId = RecordId.From("user", request.RequestorDocument);

            // Fetch user with their roles and cell info
            var result = await session.Query(@$"
                {{
                    LET $user_data = (
                        SELECT
                            *,
                            (->member_of.out.name) AS roles,
                            (->disciple_in.out)[0] AS cell_id,
                            (city OR (->disciple_in.out.located_in.out.part_of.out.name)[0] OR '') AS city,
                            (locality OR (->disciple_in.out.located_in.out.name)[0] OR '') AS locality
                        FROM {userId}
                    )[0];

                    IF $user_data == NONE {{
                        THROW 'User not found';
                    }};

                    RETURN {{
                        user: $user_data,
                        is_admin: fn::is_authorized({requestorId}, ['Admin', 'Coordinator']),
                        is_mate: (IF $user_data.cell_id != NONE THEN count(SELECT * FROM disciple_in WHERE out = $user_data.cell_id AND in = {requestorId}) > 0 ELSE false END),
                        is_leader: fn::is_leader({requestorId}, {userId}),
                        leaders: (IF $user_data.cell_id != NONE THEN (SELECT VALUE in.* FROM leads WHERE out = $user_data.cell_id) ELSE [] END)
                    }};
                }}
            ", cancellationToken);

            if (result.HasErrors)
            {
                var error = result.Errors.First();
                if (error is SurrealDbErrorResult errorRes)
                    throw new DatabaseExecutionException($"SurrealDB Error: {errorRes.Details}");

                throw new DatabaseExecutionException($"SurrealDB Error: {error}");
            }

            var data = result.GetValue<GetUserInfoDbResult>(0) ?? throw new Exception("Unexpected null from DB");

            if (data?.User == null)
                throw new NotFoundException("User not found");

            // Access Control Logic
            if (request.RequestorDocument == request.Document)
            {
                return new GetUserInfoResponse(data.User, null, data.Leaders);
            }

            // Admin/Coordinator check
            if (data.IsAdmin)
            {
                return new GetUserInfoResponse(data.User, AccessType.Admin, data.Leaders);
            }

            // Cell mate check
            if (data.IsMate)
            {
                return new GetUserInfoResponse(data.User, AccessType.Mate, data.Leaders);
            }

            // Leader check (Recursive)
            if (data.IsLeader)
            {
                return new GetUserInfoResponse(data.User, AccessType.Leader, data.Leaders);
            }

            // If user has no cell, allow fetching (for adding to a cell)
            var hasCellResult = await session.Query(@$"SELECT count() > 0 as has FROM disciple_in WHERE in = {userId}", cancellationToken);
            var hasCellData = hasCellResult.GetValue<dynamic>(0);
            if (hasCellData == null || !(bool)hasCellData!.has)
            {
                return new GetUserInfoResponse(data.User, null, data.Leaders);
            }

            throw new NotAuthorizedException();
        }
    }
}
