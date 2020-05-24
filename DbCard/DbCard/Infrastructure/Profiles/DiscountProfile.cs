using AutoMapper;

namespace DbCard.Infrastructure.Profiles
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Domain.StandartDiscount, Dto.Balance.StandartDiscount>();
            CreateMap<Domain.PremiumDiscount, Dto.Balance.PremiumDiscount>();
            CreateMap<Domain.PremiumDiscount, Dto.Balance.MyDiscount>()
                .ForMember(x => x.PartnerName, e => e.MapFrom(p => p.Partner.Name));
            CreateMap<Domain.CustomersBalance, Dto.Balance.MyDiscount>();
        }
    }
}
