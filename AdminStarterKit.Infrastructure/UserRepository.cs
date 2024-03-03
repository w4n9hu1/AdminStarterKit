using AdminStarterKit.Domain;
using AdminStarterKit.Domain.Enums;

namespace AdminStarterKit.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        public User Find(string email, string password)
        {
            var users = new List<User>()
            {
                new User() { UserId = 1, UserName = "admin",Email="admin@gmail.com",
                    Password = "admin123",Roles=new List<Role>{ new Role { RoleId=1,Name=RoleName.Admin},new Role { RoleId=2,Name=RoleName.Operator} }},
                new User() { UserId = 2, UserName = "operator",Email="operator@gmail.com",  Password = "operator1234" ,
                    Roles=new List<Role>{ new Role { RoleId=1,Name=RoleName.Operator} }},
            };
            return users.FirstOrDefault(user => user.Email.ToLower() == email.ToLower() && user.Password == password);
        }
    }
}
