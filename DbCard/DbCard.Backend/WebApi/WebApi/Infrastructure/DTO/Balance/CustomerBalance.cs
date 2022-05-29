namespace WebApi.Infrastructure.DTO.Balance
{
    public class CustomerBalance: BalanceBase
    {
        public DateTime? ResetDate { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? AccumulationPercent { get; set; }
    }
}
