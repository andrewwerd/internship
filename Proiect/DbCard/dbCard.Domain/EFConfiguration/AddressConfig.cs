using dbCard.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dbCard.Domain.EFConfiguration
{
   public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Country).IsRequired();

            builder.Property(b => b.HouseNumber).IsRequired();

            builder.Property(b => b.Region).IsRequired();

            builder.Property(b => b.Street).IsRequired();

            builder.Property(b => b.City).IsRequired();

            builder.Property(b => b.Country).IsRequired();

            builder.Property(b => b.RowVersion)
                .IsRowVersion();

            builder.HasOne(a => a.Filial)
                   .WithOne(p => p.Address)
                   .HasForeignKey<Address>(d => d.FilialId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
