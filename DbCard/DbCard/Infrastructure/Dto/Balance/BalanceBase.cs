using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.Dto.Balance
{
    public abstract class BalanceBase
    {
        public long Id { get; set; }
        public long PartnerId { get; set; }
        public string PartnerName { get; set; }
        public Category.Category Category { get; set; }
        public Category.Subcategory Subcategory { get; set; }
        public decimal CurrentAmount { get; set; }
        public virtual decimal NextAmount { get; set; }
        public bool IsPremium { get; set; }
        public List<Discount> Discounts { get; set; }
    }
}
