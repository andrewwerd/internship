using DbCard.Domain;
using System.Threading.Tasks;

namespace DbCard.Services
{
    public interface IBalanceService
    {
        Task CheckBalance(CustomersBalance balance);
    }
}