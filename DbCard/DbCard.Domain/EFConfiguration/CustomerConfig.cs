using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbCard.Domain.EFConfiguration
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasIndex(e => e.UserId)
                 .IsUnique();

            builder.Property(e => e.DateOfBirth).HasColumnType("date");

            builder.HasOne(e => e.User)
                .WithOne(y => y.Customer)
                .HasForeignKey<Customer>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);

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

            builder.Property(b => b.RowVersion)
                .IsRowVersion();

            builder.Property(b => b.RowVersion)
                   .IsRowVersion();
        }
    }
}
