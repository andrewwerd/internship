using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbCard.Domain.EFConfiguration
{
    public class FavoritePartnersConfig : IEntityTypeConfiguration<FavoritePartners>
    {
        public void Configure(EntityTypeBuilder<FavoritePartners> builder)
        {
            builder.HasOne(d => d.Customer)
                       .WithMany(p => p.FavoritePartners)
                       .HasForeignKey(d => d.CustomerId)
                       .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Partner)
                .WithMany(p => p.MyCustomers)
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
        }
    }
}
