using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.Dto.Partner
{
    public class PartnerGridRow
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public bool IsPremium { get; set; }
    }
}
