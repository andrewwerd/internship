using dbCard.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dbCard.Domain.EFConfiguration
{
    public class FilialConfig : IEntityTypeConfiguration<Filial>
    {
        public void Configure(EntityTypeBuilder<Filial> builder)
        {
            builder.HasIndex(e => e.PhoneNumber)
                     .IsUnique();

            builder.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15);

            builder.HasOne(d => d.Partner)
                .WithMany(p => p.Filials)
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
