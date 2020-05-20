using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbCard.Domain.EFConfiguration
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

            builder.Property(e => e.BirthdayDiscount).HasColumnType("decimal(4, 2)");

            builder.Property(e => e.DateOfRegistration)
                .HasColumnType("date")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.Description)
                .IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany(p => p.Partners)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Subcategory)
                .WithMany(p => p.Partners)
                .HasForeignKey(x => x.SubcategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.Rating).HasColumnType("decimal(4, 2)");

            builder.HasOne(d => d.User)
                .WithOne(p => p.Partner)
                .HasForeignKey<Partner>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
