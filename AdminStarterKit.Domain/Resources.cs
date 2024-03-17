using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminStarterKit.Domain
{
    public static class Resources
    {
        public static string EmailNotFound(string email) => $"Email '{email}' does not exist.";

        public static string UserNotFound() => $"User does not exist.";

        public static string PasswordMismatch() => $"Incorrect password.";

        public static string DuplicateEmail(string email) => $"Email '{email}' is already taken.";

        public static string ChangePasswordSuccessful() => $"Change password successful.";

        public static string DuplicateRoleName(string email) => $"RoleName '{email}' is already taken.";

        public static string NotFound(string entity) => $"'{entity}' does not exist.";
    }
}
