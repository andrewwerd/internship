using DbCard.Domain;
using DbCard.Infrastructure.Dto.Balance;
using DbCard.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbCard.Services
{
    public interface IBalanceService
    {
        Task CheckBalance(CustomersBalance balance);
        Task<IEnumerable<CustomerBalance>> GetBalancesPaged(PagedRequest scrollRequest);
    }
}