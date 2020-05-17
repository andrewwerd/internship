using DbCard.Domain.Auth;
using DbCard.Infrastructure.Dto.Balance;
using DbCard.Infrastructure.Dto.Customer;
using DbCard.Infrastructure.Dto.Partner;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbCard.Services
{
    public interface ICustomerService
    {
        Task<bool> CreateAsync(Domain.Customer customer, User user);
        Task<bool> MapAsync(CustomerForRegistration customerDto);
        Task<bool> UpdateAsync(long id, CustomerForRegistration customerDto);
        Task<IEnumerable<PremiumBalance>> MyDiscounts(long id);
        void AddFavoritePartner(long id, PartnerGridRow partnerDto);
        void DeleteFavoritePartner(long customerId, long partnerId);
        Task<Customer> GetCurrentUser();
        Task<IEnumerable<Domain.Customer>> GetAll();
    }
}
