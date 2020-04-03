using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class PremiumDiscount : Entity<long>
    {
        [Range(0,100)]
        public decimal PriceOfDiscount { get; set; }
        [Range(0, 100)]
        public decimal DiscountPercent { get; set; }
        [Range(0, 100)]
        public decimal AccumulationPercent { get; set; }
        public long PartnerId { get; set; }
        public virtual Partner Partner { get; set; }
    }
}