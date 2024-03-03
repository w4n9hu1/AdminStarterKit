using AdminStarterKit.Domain.Shared;

namespace AdminStarterKit.Domain.Identity
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public bool IsLocked { get; set; }
        public List<Role> Roles { get; set; } = new List<Role>();

        private ActionResult CreateAsync(User user)
        {

            return ActionResult.Success;
        }
    }
}
