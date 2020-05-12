using AutoMapper;
using DbCard.Infrastructure.Dto.Partner;

namespace DbCard.Infrastructure.Profiles.Partners
{
    public class PartnerProfile : Profile
    {
        public PartnerProfile()
        {
            CreateMap<Domain.Partner, PartnerGridRow>()
                .ForMember(x => x.Logo, e => e.MapFrom(z => z.Logo));
            CreateMap<PartnerForRegistration, Domain.Partner>()
                .ForMember(x => x.Logo, e => e.MapFrom(z => z.Logo))
                .ForMember(x => x.Filials, e => e.MapFrom(z => z.Filial));
        }
    }
}
