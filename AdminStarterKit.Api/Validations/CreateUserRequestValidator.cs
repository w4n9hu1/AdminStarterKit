using AdminStarterKit.Api.Contracts;
using FluentValidation;

namespace AdminStarterKit.Api.Validations
{
    public class CreateUserRequestValidator: AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
            RuleFor(x => x.UserName).NotEmpty().MinimumLength(3).MaximumLength(50)
                .WithMessage("username's length should be 3-50");
        }
    }
}
