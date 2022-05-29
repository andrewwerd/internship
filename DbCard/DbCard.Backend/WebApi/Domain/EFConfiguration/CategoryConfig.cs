using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EFConfiguration
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(b => b.RowVersion)
                   .IsRowVersion();
            builder.HasIndex(x => x.Name)
                .IsUnique();
        }
    }
}
