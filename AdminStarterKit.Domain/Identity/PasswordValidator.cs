using AdminStarterKit.Domain.Shared;

namespace AdminStarterKit.Domain.Identity
{
    public class PasswordValidator
    {
        private const int _requiredLength = 8;

        public static ActionResult Validate(User user)
        {
            var errors = ValidatePassword(user.Password, _requiredLength);
            return errors?.Count > 0 ? ActionResult.Failed(errors) : ActionResult.Success;
        }

        private static List<string> ValidatePassword(string password, int requiredLength)
        {
            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(password) || password.Length < requiredLength)
            {
                errors.Add(Resources.PasswordTooShort(_requiredLength));
            }
            return errors;
        }
    }
}
