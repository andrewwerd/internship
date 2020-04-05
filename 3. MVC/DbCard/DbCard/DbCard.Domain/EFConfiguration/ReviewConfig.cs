using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbCard.Domain.EFConfiguration
{
    public class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(b => b.RowVersion)
                .IsRowVersion();
            builder.Property(e => e.Body)
                     .IsRequired()
                     .HasMaxLength(1000);

            builder.HasOne(d => d.AnswerReviewNavigation)
                .WithMany(p => p.InverseAnswerReviewNavigation)
                .HasForeignKey(d => d.AnswerReview);

            builder.HasOne(d => d.Customer)
                .WithMany(p => p.Reviews)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Partner)
                .WithMany(p => p.Reviews)
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
