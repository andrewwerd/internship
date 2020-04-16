using AutoMapper;
using DbCard.Domain;
using DbCard.Infrastructure.DTO.PartnerDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.Profiles.Partners
{
    public class PartnerProfile : Profile
    {
        public PartnerProfile()
        {
            CreateMap<Partner, PartnerDto>()
                .ForMember(x => x.Logo, y => y.MapFrom(z => z.Logo));
            CreateMap<Partner, PartnerForGrid>()
                .ForMember(x => x.Logo, e => e.MapFrom(z => z.Logo));
            CreateMap<Partner, PartnerForRegistration>()
                .ForMember(x => x.Logo, e => e.MapFrom(z => z.Logo));
                //.ForMember(x=>x.Filials, e=>e.MapFrom(z=>z.Filials));

            CreateMap<Partner, PartnerForUpdate>();
        }
    }
}
