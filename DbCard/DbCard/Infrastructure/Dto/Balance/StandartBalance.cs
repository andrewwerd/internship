using DbCard.Infrastructure.Dto.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.Dto.Balance
{
    public class StandartBalance : BalanceBase
    {
        public DateTime ResetDate { get; set; }
    }
}
