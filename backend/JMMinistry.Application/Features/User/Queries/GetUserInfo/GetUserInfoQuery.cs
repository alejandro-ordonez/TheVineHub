using System.ComponentModel.DataAnnotations.Schema;
using JMMinistry.Application.Features.User.Dtos;
using JMMinistry.Application.Features.User.Commands.Authenticate;
using JMMinistry.Application.Features.User.Commands.CreateUser;
using JMMinistry.Application.Features.User.Commands.MarryLeaders;
using Mediator;

namespace JMMinistry.Application.Features.User.Queries.GetUserInfo
{
    public class GetUserInfoQuery : IQuery<UserInfoDto>
    {
        [Column("document")]
        public string? Document { get; set; } = string.Empty;
        [Column("requestor_document")]
        public string RequestorDocument { get; set; } = string.Empty;
    }
}
