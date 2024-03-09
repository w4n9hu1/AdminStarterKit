using AdminStarterKit.Api.Contracts;
using FluentValidation;

namespace AdminStarterKit.Api.Validations
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
        }
    }

    public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
    {
        public ChangePasswordRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.NewPassword).NotEmpty().MinimumLength(6).MaximumLength(20);
            RuleFor(x => x.OldPassword).NotEmpty();
        }
    }
}
