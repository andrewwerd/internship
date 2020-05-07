using DbCard.Infrastructure.DTO.Balance;
using DbCard.Infrastructure.DTO.Customer;
using DbCard.Infrastructure.DTO.Partner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> CreateAsync(CustomerForRegistration customerDto);
        Task<bool> UpdateAsync(long id, CustomerForRegistration customerDto);
        Task<IEnumerable<PremiumBalanceDto>> MyDiscounts(long id);
        void AddFavoritePartner(long id, PartnerDto partnerDto);
        void DeleteFavoritePartner(long customerId, long partnerId);
    }
}
