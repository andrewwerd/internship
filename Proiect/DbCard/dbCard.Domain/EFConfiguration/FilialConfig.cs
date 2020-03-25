using dbCard.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace dbCard.Domain.EFConfiguration
{
    public class FilialConfig : IEntityTypeConfiguration<Filial>
    {
        public void Configure(EntityTypeBuilder<Filial> builder)
        {
            builder.HasIndex(e => e.PhoneNumber)
                     .HasName("UQ__Filials__85FB4E386E137F2D")
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
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Filials__Partner__72C60C4A");
        }
    }
}
