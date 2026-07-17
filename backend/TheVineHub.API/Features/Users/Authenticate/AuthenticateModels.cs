using Mediator;
using FluentValidation;
using TheVineHub.API.Common;

namespace TheVineHub.API.Features.Users.Authenticate
{
    public sealed record AuthenticateCommand(string Document, string Password) : ICommand<TokenResult>;

    public class AuthenticateValidator : AbstractValidator<AuthenticateCommand>
    {
        public AuthenticateValidator()
        {
            RuleFor(auth => auth.Document)
                .NotEmpty()
                .NotNull()
                .MinimumLength(6);

            RuleFor(auth => auth.Password)
                .NotEmpty()
                .NotNull()
                .MinimumLength(8);
        }
    }
}
