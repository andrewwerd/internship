using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace dbCard.Domain.EFConfiguration
{
   public class PartnerConfig : IEntityTypeConfiguration<Partner>
    {
        public void Configure(EntityTypeBuilder<Partner> builder)
        { 
            builder.HasIndex(e => e.UserId)
                    .HasName("UQ__Partners__1788CC4D82E8ECAA")
                    .IsUnique();

            builder.Property(e => e.BirthdayDiscount).HasColumnType("decimal(3, 2)");

            builder.Property(e => e.Category)
                .IsRequired()
                .HasMaxLength(40)
                .HasDefaultValueSql("('UNIVERSAL')");

            builder.Property(e => e.DateOfRegistration)
                .HasColumnType("date")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(4000);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.Rating).HasColumnType("decimal(2, 2)");

            builder.HasOne(d => d.User)
                .WithOne(p => p.Partner)
                .HasForeignKey<Partner>(d => d.UserId)
                .HasConstraintName("FK__Partners__UserId__4CA06362");
        }
    }
}
