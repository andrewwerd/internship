using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DbCard.Infrastructure.Dto.Balance
{
    public class CustomerBalance: BalanceBase
    {
        public DateTime? ResetDate { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? AccumulationPercent { get; set; }
    }
}
