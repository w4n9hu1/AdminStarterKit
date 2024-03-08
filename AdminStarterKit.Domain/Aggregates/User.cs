namespace AdminStarterKit.Domain.Aggregates
{
    public class User : Entity, IAggregateRoot
    {
        public string PasswordHash { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public bool IsLocked { get; set; }

        public DateTimeOffset CreatedDateTime { get; set; }

        public DateTimeOffset UpdatedDateTime { get; set; }

        public IEnumerable<Role> Roles { get; set; }
    }
}
