using AutoMapper;
using WebApi.Infrastructure.DTO.Customer;

namespace WebApi.Infrastructure.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerForRegistration, Domain.Customer>();
            CreateMap<Customer, Domain.Customer>();
            CreateMap<Domain.Customer, Customer>()
                .ForMember(x=>x.Barcode,e=>e.MapFrom(p=>p.Barcode));
        }

    }
}
