using System.ComponentModel.DataAnnotations.Schema;
using JMMinistry.Application.Common;
﻿using FluentValidation;

namespace JMMinistry.Application.Features.User.Commands.Authenticate
{
    public class AuthenticateDto
    {
        [Column("document")]
        public string Document { get; set; } = string.Empty;

        [Column("password")]

        public string Password { get; set; } = string.Empty;
    }

    public class AuthenticateValidator : BaseValidator<AuthenticateDto>
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
