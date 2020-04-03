using dbCard.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dbCard.Domain.EFConfiguration
{
    public class PartnerConfig : IEntityTypeConfiguration<Partner>
    {
        public void Configure(EntityTypeBuilder<Partner> builder)
        {
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
            builder.ToTable("Partners");

            builder.HasIndex(e => e.UserId)
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
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
