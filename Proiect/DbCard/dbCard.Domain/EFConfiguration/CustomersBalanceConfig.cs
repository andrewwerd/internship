﻿using dbCard.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dbCard.Domain.EFConfiguration
{
    public class CustomersBalanceConfig : IEntityTypeConfiguration<CustomersBalance>
    {
        public void Configure(EntityTypeBuilder<CustomersBalance> builder)
        {
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
            builder.Property(e => e.AccumulatedAmount).HasColumnType("decimal(10, 2)");

            builder.Property(e => e.PaidAmount).HasColumnType("decimal(10, 2)");

            builder.Property(e => e.ResetDate).HasColumnType("datetime");

            builder.HasOne(d => d.Customer)
                .WithMany(p => p.CustomersBalances)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Partner)
                .WithMany(p => p.CustomersBalances)
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
