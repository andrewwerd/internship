using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using dbCard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace dbCard.Domain.EFConfiguration
{
    public class TransactionConfig : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("TransactionHistory");
            builder.Property(e => e.AccumulationAmount).HasColumnType("decimal(10, 2)");

            builder.Property(e => e.AllAmount).HasColumnType("decimal(10, 2)");

            builder.Property(e => e.AmountForPay).HasColumnType("decimal(10, 2)");

            builder.Property(e => e.Category)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.DiscountAmount).HasColumnType("decimal(10, 2)");

            builder.Property(e => e.FilialAddress)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.PartnerName)
                .IsRequired()
                .HasMaxLength(40);

            builder.HasOne(d => d.Customer)
                .WithMany(p => p.Transactions)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__Custo__1DB06A4F");

            builder.HasOne(d => d.Filial)
                .WithMany(p => p.Transactions)
                .HasForeignKey(d => d.FilialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__Filia__1EA48E88");
        }
    }
}
