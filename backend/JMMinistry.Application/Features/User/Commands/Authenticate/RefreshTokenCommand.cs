using System.ComponentModel.DataAnnotations.Schema;
using JMMinistry.Application.Features.User.Dtos;
using JMMinistry.Application.Features.User.Commands.Authenticate;
using JMMinistry.Application.Features.User.Commands.CreateUser;
using JMMinistry.Application.Features.User.Commands.MarryLeaders;
using Mediator;

namespace JMMinistry.Application.Features.User.Commands.RefreshToken
{
    public class RefreshTokenCommand : ICommand<TokenResult>
    {
        [Column("token")]
        public required string Token { get; set; }
        [Column("refresh_token")]
        public required string RefreshToken { get; set; }
    }
}