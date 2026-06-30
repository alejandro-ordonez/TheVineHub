using JMMinistry.Application.Common;
using JMMinistry.Application.Features.User.Dtos;
using JMMinistry.Application.Features.User.Enums;
using JMMinistry.Application.Exceptions;
using Mediator;
using SurrealDb.Net;
using SurrealDb.Net.Models.Response;
using System.Linq;
using System.Text.Json.Serialization;
using SurrealDb.Net.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace JMMinistry.Application.Features.User.Queries.GetUserInfo
{
    public class GetUserInfoHandler(ISurrealDbSession session)
        : IQueryHandler<GetUserInfoQuery, UserInfoDto>
    {
        private class UserInfoQueryResult
        {
            [Column("user")]
            public UserInfoDto User { get; set; } = null!;
            [Column("is_admin")]
            public bool IsAdmin { get; set; }
            [Column("is_mate")]
            public bool IsMate { get; set; }
            [Column("is_leader")]
            public bool IsLeader { get; set; }
            [Column("leaders")]
            public List<LeaderInfoDto> Leaders { get; set; } = [];
        }

        public async ValueTask<UserInfoDto> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
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
                    throw new Exception($"SurrealDB Error: {errorRes.Details}");

                throw new Exception($"SurrealDB Error: {error}");
            }

            var data = result.GetValue<UserInfoQueryResult>(0) ?? throw new Exception("Unexpected null from DB");

            if (data?.User == null)
                throw new NotFoundException("User not found");

            UserInfoDto userInfo = data.User;

            // Access Control Logic
            if (request.RequestorDocument == request.Document)
                return userInfo;

            // Admin/Coordinator check
            if (data.IsAdmin)
            {
                userInfo.AccessType = AccessType.Admin;
                return userInfo;
            }

            // Cell mate check
            if (data.IsMate)
            {
                userInfo.AccessType = AccessType.Mate;
                return userInfo;
            }

            // Leader check (Recursive)
            if (data.IsLeader)
            {
                userInfo.AccessType = AccessType.Leader;
                return userInfo;
            }

            // If user has no cell, allow fetching (for adding to a cell)
            var hasCellResult = await session.Query(@$"SELECT count() > 0 as has FROM disciple_in WHERE in = {userId}", cancellationToken);
            var hasCellData = hasCellResult.GetValue<dynamic>(0);
            if (hasCellData == null || !(bool)hasCellData!.has)
                return userInfo;

            throw new NotAuthorizedException();
        }
    }
}
