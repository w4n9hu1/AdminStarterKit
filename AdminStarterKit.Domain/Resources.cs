using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminStarterKit.Domain
{
    public static class Resources
    {
        public static string DuplicateEmail(string email) => $"Email '{email}' is already taken.";

        public static string PasswordMismatch() => $"Incorrect password.";

        public static string NotFound(string entity) => $"'{entity}' does not exist.";
    }
}
