using System;

namespace DbCard.Domain.QueryModels
{
    public class PartnerStatistic
    {
        public long FilialId { get; set; }
        public long PartnerId { get; set; }
        public long CustomerId { get; set; }
        public int DayOfWeek { get; set; }
        public DateTime DateTime { get; set; }
        public string PartnerName { get; set; }
        public string Address { get; set; }
    }
}
