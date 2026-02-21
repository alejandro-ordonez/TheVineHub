using JMMinistry.Common.Dtos.User;
using Mediator;

namespace JMMinistry.Application.Features.User.Queries.GetUserInfo
{
    public class GetUserInfoQuery : IQuery<UserInfoDto>
    {
        public string? Document { get; set; } = string.Empty;
        public string RequestorDocument { get; set; } = string.Empty;
    }
}
