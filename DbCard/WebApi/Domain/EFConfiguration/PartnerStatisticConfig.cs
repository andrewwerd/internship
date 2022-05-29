using Domain.QueryModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EFConfiguration
{
    public class PartnerStatisticConfig : IEntityTypeConfiguration<PartnerStatistic>
    {
        public void Configure(EntityTypeBuilder<PartnerStatistic> builder)
        {
            builder.HasNoKey();
            builder.ToView("PartnerStatisticView");
        }
    }
}
