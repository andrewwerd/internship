using System.Linq;

namespace DbCard.Infrastructure.Dto.Balance
{
    public class PremiumBalance : BalanceBase
    {
        public override decimal NextAmount
        {
            get
            {
                var d = Discounts.OrderBy(x => x.PriceOfDiscount).FirstOrDefault(x => x.PriceOfDiscount > CurrentAmount);
                return (d != null) ? d.PriceOfDiscount : 0;
            }
        }
        public decimal DiscountPercent => CurDiscount.DiscountPercent;
        public decimal? AccumulationPercent => CurDiscount.AccumulationPercent;
        private Discount CurDiscount
        {
            get
            {
                var d = Discounts.OrderBy(x => x.PriceOfDiscount);
                return d.LastOrDefault(x => x.PriceOfDiscount < CurrentAmount) ?? d.Last();
            }
        }
    }
}
