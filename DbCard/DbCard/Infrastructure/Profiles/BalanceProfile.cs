using AutoMapper;
using DbCard.Domain;
using DbCard.Infrastructure.DTO.Balance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.Profiles
{
    public class BalanceProfile : Profile
    {
        public BalanceProfile()
        {
            CreateMap<CustomersBalance, PremiumBalanceDto>()
                .ForMember(x => x.Logo, e => e.MapFrom(z => z.Partner.Logo))
                .ForMember(x => x.Discounts, e => e.MapFrom(z => z.Partner.PremiumDiscount))
                .ForMember(x => x.Category, e => e.MapFrom(z => z.Partner.Category))
                .ForMember(x => x.Subcategory, e => e.MapFrom(z => z.Partner.Subcategory))
                .ForMember(x => x.CurrentAmount, e => e.MapFrom(z => z.AccumulatedAmount));
            CreateMap<Partner, PartnerForGrid>()
                .ForMember(x => x.Logo, e => e.MapFrom(z => z.Logo));
            CreateMap<Partner, PartnerForRegistration>()
                .ForMember(x => x.Logo, e => e.MapFrom(z => z.Logo));
            //.ForMember(x=>x.Filials, e=>e.MapFrom(z=>z.Filials));

            CreateMap<Partner, PartnerForUpdate>();
        }
    }
}
