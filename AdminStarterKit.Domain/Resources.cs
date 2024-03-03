namespace AdminStarterKit.Domain
{
    public static class Resources
    {
        public static string DuplicateEmail(string email) => $"Email '{email}' is already taken.";
        public static string PasswordTooShort(int minLength) => $"Passwords must be at least {minLength} characters.";
        public static string UserNameNotFound(string email) => $"Email '{email}' does not exist.";
        public static string PasswordMismatch() => $"Incorrect password.";
    }
}
