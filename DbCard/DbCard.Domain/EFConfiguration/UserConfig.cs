using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbCard.Domain.EFConfiguration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
            builder.ToTable("Users");

            builder.HasIndex(e => e.Email)
                      .IsUnique();

            builder.HasIndex(e => e.UserName)
                .IsUnique();

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
