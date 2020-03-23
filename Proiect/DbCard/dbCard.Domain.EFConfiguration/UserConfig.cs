using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace dbCard.Domain.EFConfiguration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(e => e.Email)
                      .HasName("UQ__Users__A9D10534FDB9EF62")
                      .IsUnique();

            builder.HasIndex(e => e.UserName)
                .HasName("UQ__Users__C9F2845668362305")
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
