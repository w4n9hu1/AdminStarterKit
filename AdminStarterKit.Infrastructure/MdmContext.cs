using AdminStarterKit.Domain.Aggregates;
using AdminStarterKit.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace AdminStarterKit.Infrastructure
{
    public class MdmContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfig());
            modelBuilder.ApplyConfiguration(new RoleEntityConfig());
        }
    }
}
