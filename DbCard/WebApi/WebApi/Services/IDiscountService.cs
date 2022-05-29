using Domain;
using WebApi.Infrastructure.DTO.Balance;
using WebApi.Infrastructure.Models;

namespace WebApi.Services
{
    public interface IDiscountService
    {
        Task<IEnumerable<MyDiscount>> GetMyDiscountsPaged(PagedRequest scrollRequest);
        Domain.StandartDiscount GetStandartDiscountByBalanceAsync(CustomersBalance balance, decimal amount);
        Domain.PremiumDiscount GetPremiumDiscountByBalanceAsync(CustomersBalance balance);
        Task<decimal> GetPremiumPrice(long id);
    }
}
