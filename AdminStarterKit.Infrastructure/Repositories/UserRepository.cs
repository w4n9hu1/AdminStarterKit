using AdminStarterKit.Domain;
using AdminStarterKit.Domain.Aggregates;

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
            var user = await _mdmContext.Users.FindAsync(userId);
            return user;
        }
    }
}
