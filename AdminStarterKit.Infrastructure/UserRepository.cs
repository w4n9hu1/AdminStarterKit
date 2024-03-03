using AdminStarterKit.Domain;
using AdminStarterKit.Domain.Enums;
using AdminStarterKit.Domain.Identity;

namespace AdminStarterKit.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> FindByEmailAsync(string email)
        {
            var users = new List<User>()
            {
                new User() { UserId = 1, UserName = "admin",Email="admin@gmail.com",
                    PasswordHash = "admin123",Roles=new List<Role>{ new Role { RoleId=1,Name=RoleName.Admin},new Role { RoleId=2,Name=RoleName.Operator} }},
                new User() { UserId = 2, UserName = "operator",Email="operator@gmail.com",  PasswordHash = "operator1234" ,
                    Roles=new List<Role>{ new Role { RoleId=1,Name=RoleName.Operator} }},
            };
            await Task.Delay(10);
            return users.FirstOrDefault(user => user.Email.ToLower() == email.ToLower());
        }

        public Task<User> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
