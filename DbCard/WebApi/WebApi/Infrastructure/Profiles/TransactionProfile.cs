using AutoMapper;
using WebApi.Infrastructure.DTO.Transaction;

namespace WebApi.Infrastructure.Profiles
{
    public class TransactionProfile: Profile
    {
        public TransactionProfile()
        {
            CreateMap<Domain.Transaction, TransactionGridRow>()
                .ForMember(x => x.Category, e => e.MapFrom(p => p.Category.Name))
                .ForMember(x => x.Subcategory, e => e.MapFrom(p => p.Subcategory.Name));
        }
    }
}
