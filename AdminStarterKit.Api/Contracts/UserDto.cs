namespace AdminStarterKit.Api.Contracts
{
    public class UserDto
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public bool IsLocked { get; set; }

        public IEnumerable<RoleDto> Roles { get; set; }
    }
}
