using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace dbCard.Domain.EFConfiguration
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasIndex(e => e.UserId)
                 .HasName("UQ__Customer__1788CC4D4F091CB7")
                 .IsUnique();

            builder.Property(e => e.DateOfBirth).HasColumnType("date");

            builder.Property(e => e.DateOfRegistration)
                .HasColumnType("date")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.Gender)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(40);

            builder.HasOne(d => d.User)
                .WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.UserId)
                .HasConstraintName("FK__Customers__UserI__45F365D3");
        }
    }
}
