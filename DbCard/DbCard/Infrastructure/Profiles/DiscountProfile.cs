using AutoMapper;

namespace DbCard.Infrastructure.Profiles
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Domain.StandartDiscount, Dto.Balance.StandartDiscount>();
            CreateMap<Domain.PremiumDiscount, Dto.Balance.PremiumDiscount>();
            CreateMap<Domain.CustomersBalance, Dto.Balance.MyDiscount>();
        }
    }
}
