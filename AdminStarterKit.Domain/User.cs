using AdminStarterKit.Domain.Enums;

namespace AdminStarterKit.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
