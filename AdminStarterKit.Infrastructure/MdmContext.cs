using AdminStarterKit.Domain;
using AdminStarterKit.Domain.Aggregates;
using AdminStarterKit.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace AdminStarterKit.Infrastructure
{
    public class MdmContext: DbContext, IUnitOfWork
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public MdmContext(DbContextOptions<MdmContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfig());
            modelBuilder.ApplyConfiguration(new RoleEntityConfig());
        }
    }
}
