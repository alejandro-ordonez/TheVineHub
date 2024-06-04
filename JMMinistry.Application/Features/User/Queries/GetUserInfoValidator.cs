using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.User.Queries
{
    public class GetUserInfoValidator: AbstractValidator<GetUserInfoQuery>
    {
        public GetUserInfoValidator()
        {
            RuleFor(request => request.Document)
                .NotEmpty()
                .WithMessage("Your document cannot be empty");
        }
    }
}
