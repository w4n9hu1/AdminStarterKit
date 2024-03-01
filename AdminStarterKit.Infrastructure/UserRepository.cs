using AdminStarterKit.Domain;
using AdminStarterKit.Domain.Enums;

namespace AdminStarterKit.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        public User Find(string username, string password)
        {
            var users = new List<User>()
            {
                new User() { UserId = 42, UserName = "admin", Password = "admin123", Role = Role.Admin },
                new User() { UserId = 42, UserName = "operator", Password = "operator1234", Role = Role.Operator },
            };
            return users.FirstOrDefault(user => user.UserName.ToLower() == username.ToLower() && user.Password == password);
        }
    }
}
