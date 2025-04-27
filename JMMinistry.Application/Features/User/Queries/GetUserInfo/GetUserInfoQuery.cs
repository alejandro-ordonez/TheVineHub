using JMMinistry.Common.Dtos.User;
using MediatR;

namespace JMMinistry.Application.Features.User.Queries.GetUserInfo
{
    public class GetUserInfoQuery : IRequest<UserInfoDto>
    {
        public string? Document { get; set; } = string.Empty;
        public string RequestorDocument { get; set; } = string.Empty;
    }
}
