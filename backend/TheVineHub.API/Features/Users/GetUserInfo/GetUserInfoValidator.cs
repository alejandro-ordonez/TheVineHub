using FluentValidation;

namespace TheVineHub.API.Features.Users.GetUserInfo
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
