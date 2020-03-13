using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class TransactionHistory
    {
        public int Id { get; set; }
        public string PartnerName { get; set; }
        public string FilialAddress { get; set; }
        public string Category { get; set; }
        public decimal AllAmount { get; set; }
        public decimal AmountForPay { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal? AccumulationAmount { get; set; }
        public int CustomerId { get; set; }
        public int FilialId { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Filials Filial { get; set; }
    }
}
