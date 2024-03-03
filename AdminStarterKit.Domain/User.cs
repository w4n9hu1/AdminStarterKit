using AdminStarterKit.Domain.Enums;

namespace AdminStarterKit.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Role> Roles { get; set; } = new List<Role>();
    }

    public class Role
    {
        public int RoleId { get; set; }
        public RoleName Name { get; set; }
    }
}
