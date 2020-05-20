using DbCard.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Services.Implementations
{
    public class BalanceService : IBalanceService
    {
        private readonly IDiscountService _discountService;

        public BalanceService(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        public async Task CheckBalance(CustomersBalance balance)
        {
            var price = await _discountService.GetPremiumPrice(balance);
            if (price < balance.Amount)
            {
                balance.IsPremium = true;
                balance.Amount -= price;
                balance.ResetDate = null;
            }
            return;
        }
    }
}