using AdminStarterKit.Domain;
using AdminStarterKit.Domain.Aggregates;

namespace AdminStarterKit.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();
    }
}
