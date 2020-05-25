using DbCard.Domain;
using DbCard.Infrastructure.Dto.Balance;
using DbCard.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Services
{
    public interface IDiscountService
    {
        Task<IEnumerable<MyDiscount>> GetMyDiscountsPaged(PagedRequest scrollRequest);
        Domain.StandartDiscount GetStandartDiscountByBalanceAsync(CustomersBalance balance, decimal amount);
        Domain.PremiumDiscount GetPremiumDiscountByBalanceAsync(CustomersBalance balance);
        Task<decimal> GetPremiumPrice(long id);
    }
}
