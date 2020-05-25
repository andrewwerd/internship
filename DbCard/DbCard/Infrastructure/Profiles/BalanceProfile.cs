using AutoMapper;
using DbCard.Domain;
using DbCard.Infrastructure.Dto.Balance;
using DbCard.Services;
using System.Linq;

namespace DbCard.Infrastructure.Profiles
{
    public class BalanceProfile : Profile
    {
        public BalanceProfile()
        {
            CreateMap<CustomersBalance, StandartBalance>()
                .ForMember(x=>x.NextAmount, e=>e.MapFrom(z=>z.Partner.PremiumDiscounts.OrderBy(x=>x.PriceOfDiscount).FirstOrDefault().PriceOfDiscount))
                .ForMember(x => x.CurrentAmount, e => e.MapFrom(z => z.Amount))
                .ForMember(x => x.Category, e => e.MapFrom(p => p.Partner.Category))
                .ForMember(x => x.Subcategory, e => e.MapFrom(p => p.Partner.Subcategory))
                .ForMember(x => x.PartnerName, e => e.MapFrom(p => p.Partner.Name))
                .ForMember(x => x.Discounts, e => e.MapFrom(p => p.Partner.StandartDiscounts));


            CreateMap<CustomersBalance, PremiumBalance>()
                .ForMember(x => x.CurrentAmount, e => e.MapFrom(z => z.Amount))
                .ForMember(x => x.Category, e => e.MapFrom(p => p.Partner.Category))
                .ForMember(x => x.Subcategory, e => e.MapFrom(p => p.Partner.Subcategory))
                .ForMember(x => x.PartnerName, e => e.MapFrom(p => p.Partner.Name))
                .ForMember(x => x.Discounts, e => e.MapFrom(p => p.Partner.PremiumDiscounts));

            CreateMap<PremiumBalance, CustomerBalance>();
            CreateMap<StandartBalance, CustomerBalance>();

            CreateMap<StandartDiscount, Discount>()
                .ForMember(x => x.PriceOfDiscount, e => e.MapFrom(z => z.AmountOfDiscount));

            CreateMap<PremiumDiscount, Discount>();

            CreateMap<PremiumDiscount, MyDiscount>()
                .ForMember(x => x.PartnerName, e => e.MapFrom(p => p.Partner.Name));
            CreateMap<CustomersBalance, MyDiscount>();
        }
    }
}
