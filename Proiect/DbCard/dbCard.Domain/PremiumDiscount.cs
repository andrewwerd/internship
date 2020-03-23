namespace dbCard.Domain
{
    public class PremiumDiscount : Entity<long>
    {
        public long PremiumDiscountId { get; set; }
        public decimal PriceOfDiscount { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal AccumulationPercent { get; set; }
        public long PartnerId { get; set; }
        public virtual Partner Partner { get; set; }
    }
}