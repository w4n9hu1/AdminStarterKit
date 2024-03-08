using AdminStarterKit.Domain;
using AdminStarterKit.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace AdminStarterKit.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MdmContext _mdmContext;

        public IUnitOfWork UnitOfWork => _mdmContext;

        public UserRepository(MdmContext mdmContext)
        {
            _mdmContext = mdmContext;
        }

        public User Add(User user)
        {
            return _mdmContext.Users.Add(user).Entity;
        }

        public async Task<User> GetAsync(int userId)
        {
            return await _mdmContext.Users.FindAsync(userId);
        }

        public async Task DeleteAsync(int userId)
        {
            var user = await _mdmContext.Users.FindAsync(userId);
            if (user == null)
            {
                return;
            }
            _mdmContext.Users.Remove(user);
        }

        public void Update(User user)
        {
            _mdmContext.Entry(user).State = EntityState.Modified;
        }

        public IEnumerable<User> GetAllAsync()
        {
            return _mdmContext.Users;
        }
    }
}
