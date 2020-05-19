using DbCard.Infrastructure.Dto.Balance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Services
{
    public interface IDiscountService
    {
        Task<IEnumerable<MyDiscount>> GetMyDiscounts(long id);
    }
}
