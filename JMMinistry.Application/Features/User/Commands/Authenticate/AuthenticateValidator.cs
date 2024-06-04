using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.User.Commands.Authenticate
{
    public class AuthenticateValidator : AbstractValidator<AuthenticateCommand>
    {
        public AuthenticateValidator()
        {
            RuleFor(command => command.Document)
                .NotEmpty()
                .NotNull()
                .WithMessage("Your document cannot be empty")
                .MinimumLength(5)
                .WithMessage("The length of your document must be well formatted");

            RuleFor(command => command.Password)
                .NotEmpty()
                .WithMessage("Your password cannot be empty");
        }
    }
}
