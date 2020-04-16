using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.DTO.Balance
{
    public class StandartDiscountDto
    {
        public long Id { get; set; }
        public decimal AmountOfDiscount { get; set; }
        public decimal DiscountPercent { get; set; }
    }
}
