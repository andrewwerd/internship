using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication.Models.EFConfiguration
{
    public class NewsConfig : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
            builder.Property(e => e.Body)
                    .IsRequired()
                    .HasMaxLength(4000);

            builder.Property(e => e.DateOfCreation)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.ShortBody).HasMaxLength(100);

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(40);

            builder.HasOne(d => d.Partner)
                .WithMany(p => p.News)
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
