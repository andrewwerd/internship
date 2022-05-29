namespace WebApi.Infrastructure.DTO.Balance
{
    public class MyDiscount
    {
        public long Id { get; set; }
        public long PartnerId { get; set; }
        public string PartnerName { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal AccumulationPercent { get; set; }
    }
}
