using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbCard.Domain.EFConfiguration
{
    public class PartnerSubcategoriesConfig : IEntityTypeConfiguration<PartnerSubcategories>
    {
        public void Configure(EntityTypeBuilder<PartnerSubcategories> builder)
        {
            builder.HasOne(d => d.Subcategory)
            .WithMany(p => p.Partners)
            .HasForeignKey(d => d.SubcategoryId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Partner)
                .WithMany(p => p.PartnerSubcategories)
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
        }
    }
}
