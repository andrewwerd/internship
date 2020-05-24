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
        Task<IEnumerable<MyDiscount>> GetMyDiscountsPaged(ScrollRequest scrollRequest);
        Task<Domain.StandartDiscount> GetStandartDiscountByBalanceAsync(CustomersBalance balance, decimal amount);
        Task<Domain.PremiumDiscount> GetPremiumDiscountByBalanceAsync(CustomersBalance balance);
        Task<decimal> GetPremiumPrice(CustomersBalance balance);
    }
}
