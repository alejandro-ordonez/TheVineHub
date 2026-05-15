using JMMinistry.Common;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Common.Dtos.User.Enums;
using JMMinistry.Application.Exceptions;
using Mediator;
using SurrealDb.Net;

using System.Linq;

namespace JMMinistry.Application.Features.User.Queries.GetUserInfo
{
    public class GetUserInfoHandler(ISurrealDbSession session)
        : IQueryHandler<GetUserInfoQuery, UserInfoDto>
    {
        public async ValueTask<UserInfoDto> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            var userId = $"user:{request.Document}";
            var requestorId = $"user:{request.RequestorDocument}";

            // Fetch user with their roles and cell info
            var result = await session.Query(@$"
                LET $user_id = type::thing('user', {request.Document});
                LET $requestor_id = type::thing('user', {request.RequestorDocument});

                LET $user_data = (
                    SELECT *,
                        (SELECT VALUE out.name FROM ->member_of) AS roles,
                        (SELECT VALUE out FROM ->disciple_in)[0] AS cell_id,
                        (SELECT VALUE out.name FROM ->disciple_in->cell->located_in->locality->part_of->city)[0] AS city,
                        (SELECT VALUE out.name FROM ->disciple_in->cell->located_in->locality)[0] AS locality
                    FROM $user_id
                )[0];

                LET $cell_id = $user_data.cell_id;

                RETURN {{
                    user: $user_data,
                    is_admin: fn::is_authorized($requestor_id, ['Admin', 'Coordinator']),
                    is_mate: (IF $cell_id != NONE THEN (SELECT count() > 0 FROM disciple_in WHERE out = $cell_id AND in = $requestor_id)[0] ELSE false END),
                    is_leader: fn::is_leader($requestor_id, $user_id),
                    leaders: (IF $cell_id != NONE THEN (SELECT VALUE in.* FROM leads WHERE out = $cell_id) ELSE [] END)
                }};
            ", cancellationToken);

            var data = result.GetValue<dynamic>(0);

            if (data?.user == null)
                throw new NotFoundException("User not found");

            UserInfoDto userInfo = data.user;
            //userInfo.Leaders = data.leaders ?? new List<BasicUserInfoDto>();
            //userInfo.CellId = (string)data.user.cell_id;
            userInfo.City = (string)data.user.city ?? string.Empty;
            userInfo.Locality = (string)data.user.locality;

            // Access Control Logic
            if (request.RequestorDocument == request.Document)
                return userInfo;

            // Admin/Coordinator check
            if ((bool)data.is_admin)
            {
                userInfo.AccessType = AccessType.Admin;
                return userInfo;
            }

            // Cell mate check
            if ((bool)data.is_mate)
            {
                userInfo.AccessType = AccessType.Mate;
                return userInfo;
            }

            // Leader check (Recursive)
            if ((bool)data.is_leader)
            {
                userInfo.AccessType = AccessType.Leader;
                return userInfo;
            }

            // If user has no cell, allow fetching (for adding to a cell)
            var hasCellResult = await session.Query(@$"SELECT count() > 0 as has FROM disciple_in WHERE in = type::thing('user', {request.Document})", cancellationToken);

            if (!(bool)hasCellResult.GetValue<dynamic>(0).has)
                return userInfo;

            throw new NotAuthorizedException();
        }
    }
}
