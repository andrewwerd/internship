using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbCard.Domain.EFConfiguration
{
    class ScheduleConfig : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedules");
            builder.HasKey(x => x.Id);
            builder.HasIndex(e => e.FilialId).IsUnique();
            builder.Property(b => b.RowVersion).IsRowVersion();
            builder.Property(x => x.Monday).HasColumnType("nvarchar(30)").IsRequired().HasDefaultValue("None");
            builder.Property(x => x.Tuesday).HasColumnType("nvarchar(30)").IsRequired().HasDefaultValue("None");
            builder.Property(x => x.Wednesday).HasColumnType("nvarchar(30)").IsRequired().HasDefaultValue("None");
            builder.Property(x => x.Thursday).HasColumnType("nvarchar(30)").IsRequired().HasDefaultValue("None");
            builder.Property(x => x.Friday).HasColumnType("nvarchar(30)").IsRequired().HasDefaultValue("None");
            builder.Property(x => x.Saturday).HasColumnType("nvarchar(30)").IsRequired().HasDefaultValue("None");
            builder.Property(x => x.Sunday).HasColumnType("nvarchar(30)").IsRequired().HasDefaultValue("None");
            builder.HasOne(x => x.Filial)
                .WithOne(x => x.Schedule)
                .HasForeignKey<Schedule>(d => d.FilialId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
