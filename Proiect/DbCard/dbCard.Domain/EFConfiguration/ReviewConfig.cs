using dbCard.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace dbCard.Domain.EFConfiguration
{
    public class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(e => e.Body)
                     .IsRequired()
                     .HasMaxLength(1000);

            builder.HasOne(d => d.AnswerReviewNavigation)
                .WithMany(p => p.InverseAnswerReviewNavigation)
                .HasForeignKey(d => d.AnswerReview)
                .HasConstraintName("FK__Reviews__AnswerR__76969D2E");

            builder.HasOne(d => d.Customer)
                .WithMany(p => p.Reviews)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Reviews__Custome__4E88ABD4");

            builder.HasOne(d => d.Partner)
                .WithMany(p => p.Reviews)
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reviews__Partner__787EE5A0");
        }
    }
}
