using JMMinistry.Common.Dtos.User;
using Mediator;

namespace JMMinistry.Application.Features.User.Commands.RefreshToken
{
    public class RefreshTokenCommand : ICommand<TokenResult>
    {
        public required string Token { get; set; }
        public required string RefreshToken { get; set; }
    }
}