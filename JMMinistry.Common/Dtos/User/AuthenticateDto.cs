using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Common.Dtos.User
{
    public class AuthenticateDto
    {
        public string Document { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }

    public class AuthenticateValidator: BaseValidator<AuthenticateDto>
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
