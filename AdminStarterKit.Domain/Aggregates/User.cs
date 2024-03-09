using AdminStarterKit.Domain.Shared;

namespace AdminStarterKit.Domain.Aggregates
{
    public class User : Entity, IAggregateRoot
    {
        public string? UserName { get; set; }

        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public bool IsLocked { get; set; }

        public string PasswordHash { get; set; }

        public string? Password { get; set; }

        public bool IsAdmin { get; set; }

        public int CreatedBy { get; set; }

        public DateTimeOffset CreatedDateTime { get; set; }

        public DateTimeOffset? UpdatedDateTime { get; set; }

        public IEnumerable<Role> Roles { get; set; }

        public void HashPassWord()
        {
            if (string.IsNullOrEmpty(Password))
            {
                Password = Email;
            }
            PasswordHash = PasswordHasher.HashPassword(Password);
        }
    }
}
