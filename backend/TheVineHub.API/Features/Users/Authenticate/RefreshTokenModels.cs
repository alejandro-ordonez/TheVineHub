using Mediator;
using FluentValidation;

namespace TheVineHub.API.Features.Users.Authenticate
{
    public sealed class RefreshTokenCommand : ICommand<TokenResult>
    {
        public required string Token { get; init; }
        public required string RefreshToken { get; init; }
    }

    public class RefreshTokenValidator : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenValidator()
        {
            RuleFor(v => v.Token)
                .NotEmpty().WithMessage("The access token is required.");
            RuleFor(v => v.RefreshToken)
                .NotEmpty().WithMessage("The refresh token is required.");
        }
    }
}
