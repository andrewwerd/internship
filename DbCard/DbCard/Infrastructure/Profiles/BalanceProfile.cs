using AutoMapper;
using DbCard.Domain;
using DbCard.Infrastructure.Dto.Balance;

namespace DbCard.Infrastructure.Profiles
{
    public class BalanceProfile : Profile
    {
        public BalanceProfile()
        {
            CreateMap<CustomersBalance, CustomerBalance>()
                .ForMember(x => x.CurrentAmount, e => e.MapFrom(z => z.Amount));
        }
    }
}
