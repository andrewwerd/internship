using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbCard.Domain.EFConfiguration
{
    public class NewsConfig : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
            builder.Property(e => e.Body)
                    .IsRequired();

            builder.Property(e => e.DateOfCreation)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.ShortBody).HasMaxLength(100);

            builder.Property(e => e.Title)
                .IsRequired();

            builder.HasOne(d => d.Partner)
                .WithMany(p => p.News)
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
