using AdminStarterKit.Api.Contracts;
using FluentValidation;

namespace AdminStarterKit.Api.Validations
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.PhoneNumber).MinimumLength(11).MaximumLength(50);
            RuleFor(x => x.UserName).MinimumLength(3).MaximumLength(50)
                .WithMessage("username's length should be 3-50");
        }
    }
}
