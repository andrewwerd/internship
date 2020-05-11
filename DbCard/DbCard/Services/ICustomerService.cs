using DbCard.Infrastructure.Dto.Balance;
using DbCard.Infrastructure.Dto.Customer;
using DbCard.Infrastructure.Dto.Partner;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbCard.Services
{
    public interface ICustomerService
    {
        Task<bool> CreateAsync(CustomerForRegistration customerDto);
        Task<bool> UpdateAsync(long id, CustomerForRegistration customerDto);
        Task<IEnumerable<PremiumBalance>> MyDiscounts(long id);
        void AddFavoritePartner(long id, Partner partnerDto);
        void DeleteFavoritePartner(long customerId, long partnerId);
    }
}
