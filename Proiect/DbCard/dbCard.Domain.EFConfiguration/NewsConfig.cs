using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace dbCard.Domain.EFConfiguration
{
    public class NewsConfig : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
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
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__News__PartnerId__73BA3083");
        }
    }
}
