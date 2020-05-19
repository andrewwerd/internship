using AutoMapper;

namespace DbCard.Infrastructure.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Dto.Customer.CustomerForRegistration, Domain.Customer>()
                .ForMember(x => x.Avatar, e => e.MapFrom(p => p.Avatar));
            CreateMap<Domain.Customer, Dto.Customer.Customer>()
                .ForMember(x=>x.Barcode,e=>e.MapFrom(p=>p.Barcode));
        }

    }
}
