using AdminStarterKit.Api.Contracts;
using FluentValidation;

namespace AdminStarterKit.Api.Validations
{
    public class CreateRoleRequestValidator : AbstractValidator<CreateRoleRequest>
    {
        public CreateRoleRequestValidator()
        {
            RuleFor(x => x.RoleName).NotEmpty().MinimumLength(2).MaximumLength(50);
        }
    }
}
