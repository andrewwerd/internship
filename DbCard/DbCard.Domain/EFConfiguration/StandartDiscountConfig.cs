using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbCard.Domain.EFConfiguration
{
    public class StandartDiscountConfig : IEntityTypeConfiguration<StandartDiscount>
    {
        public void Configure(EntityTypeBuilder<StandartDiscount> builder)
        {
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
            builder.Property(e => e.AmountOfDiscount).HasColumnType("decimal(10, 2)");

            builder.Property(e => e.DiscountPercent).HasColumnType("decimal(5, 2)");

            builder.HasOne(d => d.Partner)
                .WithMany(p => p.StandartDiscounts)
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
