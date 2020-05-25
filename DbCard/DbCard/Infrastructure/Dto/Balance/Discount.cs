namespace DbCard.Infrastructure.Dto.Balance
{
    public class Discount
    {
        public long Id { get; set; }
        public decimal PriceOfDiscount { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal? AccumulationPercent { get; set; }
    }
}
