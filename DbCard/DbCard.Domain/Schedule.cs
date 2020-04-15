using System;
using System.Collections.Generic;
using System.Text;

namespace DbCard.Domain
{
    public class Schedule : Entity<long>
    {

        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }
        public long FilialId { get; set; }
        public virtual Filial Filial { get; set; }
    }
}
