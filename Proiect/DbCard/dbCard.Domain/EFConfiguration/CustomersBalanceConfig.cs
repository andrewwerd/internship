using dbCard.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace dbCard.Domain.EFConfiguration
{
    public class CustomersBalanceConfig : IEntityTypeConfiguration<CustomersBalance>
    {
        public void Configure(EntityTypeBuilder<CustomersBalance> builder)
        {
            builder.Property(e => e.AccumulatedAmount).HasColumnType("decimal(10, 2)");

            builder.Property(e => e.PaidAmount).HasColumnType("decimal(10, 2)");

            builder.Property(e => e.ResetDate).HasColumnType("datetime");

            builder.HasOne(d => d.Customer)
                .WithMany(p => p.CustomersBalances)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Customers__Custo__46E78A0C");

            builder.HasOne(d => d.Partner)
                .WithMany(p => p.CustomersBalances)
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Customers__Partn__2EDAF651");
        }
    }
}
