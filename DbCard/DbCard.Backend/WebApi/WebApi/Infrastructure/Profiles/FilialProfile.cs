using AutoMapper;
using WebApi.Infrastructure.DTO.Filial;

namespace WebApi.Infrastructure.Profiles
{
    public class FilialProfile: Profile
    {
        public FilialProfile()
        {
            CreateMap<Domain.Filial, Filial>();
            CreateMap<Filial, Domain.Filial>();
        }
    }
}
