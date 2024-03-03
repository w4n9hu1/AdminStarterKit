using AdminStarterKit.Domain.Shared;

namespace AdminStarterKit.Domain.Identity
{
    public class UserValidator : IUserValidator
    {
        private readonly IUserRepository _userRepository;

        public UserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ActionResult> ValidateAsync(User user)
        {
            var errors = await ValidateEmail(user.Email);
            return errors?.Count > 0 ? ActionResult.Failed(errors) : ActionResult.Success;
        }

        private async Task<List<string>> ValidateEmail(string email)
        {
            var errors = new List<string>();
            var user = await _userRepository.FindByEmailAsync(email);
            if (user != null)
            {
                errors.Add(Resources.DuplicateEmail(email));
            }
            return errors;
        }
    }
}
