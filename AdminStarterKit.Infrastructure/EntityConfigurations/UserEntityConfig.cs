using AdminStarterKit.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminStarterKit.Infrastructure.EntityConfigurations
{
    public class UserEntityConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("mdm_user");

            builder.HasMany(u => u.Roles).WithMany(r => r.Users)
                .UsingEntity(r => r.ToTable("mdm_user_role"));
        }
    }
}
