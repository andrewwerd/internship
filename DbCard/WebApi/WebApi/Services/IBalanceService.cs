using Domain;
using WebApi.Infrastructure.DTO.Balance;
using WebApi.Infrastructure.Models;

namespace WebApi.Services
{
    public interface IBalanceService
    {
        Task CheckBalance(CustomersBalance balance);
        Task<IEnumerable<CustomerBalance>> GetBalancesPaged(PagedRequest scrollRequest);
    }
}