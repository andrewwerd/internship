namespace DbCard.Infrastructure.Dto.Balance
{
    public class PremiumDiscount
    {
        public long Id { get; set; }
        public decimal PriceOfDiscount { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal AccumulatingPercent { get; set; }
    }
}
