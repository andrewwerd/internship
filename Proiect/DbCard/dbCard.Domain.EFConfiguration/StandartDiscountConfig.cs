using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace dbCard.Domain.EFConfiguration
{
    public class StandartDiscountConfig : IEntityTypeConfiguration<StandartDiscount>
    {
        public void Configure(EntityTypeBuilder<StandartDiscount> builder)
        {
            builder.Property(e => e.AmountOfDiscount).HasColumnType("decimal(4, 2)");

            builder.Property(e => e.DiscountPercent).HasColumnType("decimal(2, 2)");

            builder.HasOne(d => d.Partner)
                .WithMany(p => p.StandartDiscounts)
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StandartD__Partn__797309D9");
        }
    }
}
