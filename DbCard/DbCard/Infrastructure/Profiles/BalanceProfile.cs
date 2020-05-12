using AutoMapper;
using DbCard.Domain;
using DbCard.Infrastructure.Dto.Balance;

namespace DbCard.Infrastructure.Profiles
{
    public class BalanceProfile : Profile
    {
        public BalanceProfile()
        {
            CreateMap<CustomersBalance, PremiumBalance>()
                .ForMember(x => x.Logo, e => e.MapFrom(z => z.Partner.Logo))
                .ForMember(x => x.CurrentAmount, e => e.MapFrom(z => z.Amount))
                .ForMember(x => x.Discounts, e => e.MapFrom(z => z.Partner.PremiumDiscount));
            CreateMap<CustomersBalance, StandartBalance>()
                .ForMember(x => x.Logo, e => e.MapFrom(z => z.Partner.Logo))
                .ForMember(x => x.CurrentAmount, e => e.MapFrom(z => z.Amount))
                .ForMember(x => x.Discounts, e => e.MapFrom(z => z.Partner.StandartDiscounts));
        }
    }
}
