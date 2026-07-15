using System.ComponentModel.DataAnnotations.Schema;
using TheVineHub.API.Features.Users;
using Mediator;

namespace TheVineHub.API.Features.Users.GetUserInfo
{
    public sealed record GetUserInfoQuery(string Document, string RequestorDocument) : IQuery<GetUserInfoResponse>;

    internal sealed class GetUserInfoDbResult
    {
        [Column("user")]
        public UserInfoDto User { get; init; } = null!;
        [Column("is_admin")]
        public bool IsAdmin { get; init; }
        [Column("is_mate")]
        public bool IsMate { get; init; }
        [Column("is_leader")]
        public bool IsLeader { get; init; }
        [Column("leaders")]
        public List<LeaderInfoDto> Leaders { get; init; } = [];
    }

    public sealed record GetUserInfoResponse(
        UserInfoDto User,
        AccessType? AccessType,
        List<LeaderInfoDto> Leaders
    );
}
