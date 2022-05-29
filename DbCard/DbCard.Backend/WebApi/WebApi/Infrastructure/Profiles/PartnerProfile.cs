using AutoMapper;
using WebApi.Infrastructure.DTO.News;
using WebApi.Infrastructure.DTO.Partner;

namespace WebApi.Infrastructure.Profiles
{
    public class PartnerProfile : Profile
    {
        public PartnerProfile()
        {
            CreateMap<Domain.Partner, Partner>();
            CreateMap<Domain.Partner, PartnerGridRow>();
            CreateMap<PartnerForRegistration, Domain.Partner>();
            CreateMap<Domain.News, News>();
        }
    }
}
