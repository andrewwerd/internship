using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbCard.Domain.EFConfiguration
{
    public class SubcategoryConfig : IEntityTypeConfiguration<Subcategory>
    {
        public void Configure(EntityTypeBuilder<Subcategory> builder)
        {
            builder.HasOne(d => d.Category)
                       .WithMany(p => p.Subcategories)
                       .HasForeignKey(d => d.CategoryId)
                       .OnDelete(DeleteBehavior.Cascade);
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
            builder.HasIndex(x => new { x.Name, x.CategoryId })
                .IsUnique();
        }
    }
}
