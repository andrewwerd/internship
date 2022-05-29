using Domain.Auth;
using WebApi.Infrastructure.DTO.Customer;

namespace WebApi.Services
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
        Task<bool> EditCustomer(Customer customer);
    }
}
