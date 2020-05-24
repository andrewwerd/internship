using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbCard.Domain.EFConfiguration
{
    public class TransactionConfig : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
            builder.ToTable("TransactionHistory");
            builder.Property(e => e.AccumulationAmount).HasColumnType("decimal(10, 2)");

            builder.Property(e => e.AllAmount).HasColumnType("decimal(10, 2)");

            builder.Property(e => e.AmountForPay).HasColumnType("decimal(10, 2)");

            builder.HasOne(x => x.Category)
                .WithMany(p => p.Transactions)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.Subcategory)
    .WithMany(p => p.Transactions)
    .HasForeignKey(d => d.SubcategoryId)
    .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Property(e => e.DiscountAmount).HasColumnType("decimal(10, 2)");

            builder.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.PartnerName)
                .IsRequired()
                .HasMaxLength(40);

            builder.HasOne(d => d.Customer)
                .WithMany(p => p.Transactions)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Filial)
                .WithMany(p => p.Transactions)
                .HasForeignKey(d => d.FilialId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
