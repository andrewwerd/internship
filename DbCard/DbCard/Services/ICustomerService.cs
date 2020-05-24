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
        Task<bool> CreateFromDtoAsync(CustomerForRegistration customerDto, User user);
        Task<bool> UpdateAsync(long id, CustomerForRegistration customerDto);
        void AddFavoritePartner(long customerId, long partnerId);
        void DeleteFavoritePartner(long customerId, long partnerId);
        Task<Customer> GetCurrentCustomerDto();
        Task<Domain.Customer> GetCurrentCustomer();
        Task<Domain.Customer> GetByNameAsync(string userName);
        Task<bool> EditCustomer(Infrastructure.Dto.Customer.Customer customer);
    }
}
