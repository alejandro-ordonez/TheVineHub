using FluentValidation;

namespace JMMinistry.Application.Features.User.Queries.GetUserInfo
{
    public class GetUserInfoValidator : AbstractValidator<GetUserInfoQuery>
    {
        public GetUserInfoValidator()
        {
            RuleFor(request => request.RequestorDocument)
                .NotEmpty()
                .WithMessage("Your document cannot be empty");
        }
    }
}
