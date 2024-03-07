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

            builder.Property(u => u.PasswordHash).HasMaxLength(1000);
            builder.Property(u => u.Email).HasMaxLength(50);
            builder.Property(u => u.UserName).HasMaxLength(50);
            builder.Property(u => u.PhoneNumber).HasMaxLength(50);

            builder.Property(u => u.CreatedDateTime)
                   .HasColumnType("TIMESTAMP(3)")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP(3)");
            builder.Property(u => u.UpdatedDateTime)
                   .HasColumnType("TIMESTAMP(3)")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP(3)")
                   .ValueGeneratedOnUpdate();
            builder.HasMany(u => u.Roles).WithMany(r => r.Users)
                .UsingEntity(r => r.ToTable("mdm_user_role"));
        }
    }
}
