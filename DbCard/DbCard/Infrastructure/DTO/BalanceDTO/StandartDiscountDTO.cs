using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.DTO.BalanceDTO
{
    public class StandartDiscountDTO
    {
        public long Id { get; set; }
        public decimal AmountOfDiscount { get; set; }
        public decimal DiscountPercent { get; set; }
    }
}
