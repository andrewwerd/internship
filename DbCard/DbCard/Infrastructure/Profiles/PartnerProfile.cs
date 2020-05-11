using AutoMapper;
using DbCard.Domain;
using DbCard.Infrastructure.Dto.Partner;

namespace DbCard.Infrastructure.Profiles.Partners
{
    public class PartnerProfile : Profile
    {
        public PartnerProfile()
        {
            CreateMap<Domain.Partner, Dto.Partner.Partner>()
                .ForMember(x => x.Logo, y => y.MapFrom(z => z.Logo));
            CreateMap<Domain.Partner, PartnerForGrid>()
                .ForMember(x => x.Logo, e => e.MapFrom(z => z.Logo));
            CreateMap<Domain.Partner, PartnerForRegistration>()
                .ForMember(x => x.Logo, e => e.MapFrom(z => z.Logo));
            //.ForMember(x=>x.Filials, e=>e.MapFrom(z=>z.Filials));

            CreateMap<Domain.Partner, PartnerForUpdate>();
        }
    }
}
