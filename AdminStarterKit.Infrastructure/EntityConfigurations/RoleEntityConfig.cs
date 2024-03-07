using AdminStarterKit.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminStarterKit.Infrastructure.EntityConfigurations
{
    public class RoleEntityConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("mdm_role");

            builder.Property(r => r.RoleName).HasMaxLength(50);

            builder.Property(r => r.CreatedDateTime)
                .HasColumnType("TIMESTAMP(3)")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(3)");
        }
    }
}
