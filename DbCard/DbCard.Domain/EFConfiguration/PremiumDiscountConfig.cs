using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbCard.Domain.EFConfiguration
{
    public class PremiumDiscountConfig : IEntityTypeConfiguration<PremiumDiscount>
    {
        public void Configure(EntityTypeBuilder<PremiumDiscount> builder)
        {
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
            builder.Property(e => e.AccumulatingPercent).HasColumnType("decimal(2, 2)");

            builder.Property(e => e.DiscountPercent).HasColumnType("decimal(2, 2)");

            builder.Property(e => e.PriceOfDiscount).HasColumnType("decimal(10, 2)");

            builder.HasOne(d => d.Partner)
                .WithMany(p => p.PremiumDiscount)
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
