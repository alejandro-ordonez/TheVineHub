using FluentValidation;

namespace JMMinistry.Application.Features.User.Commands.RefreshToken
{
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