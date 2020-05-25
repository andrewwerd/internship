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
        public decimal Rating { get; set; }
        public Category.Category Category { get; set; }
        public Category.Subcategory Subcategory { get; set; }
        public bool IsPremium { get; set; }
        public bool IsFavorite { get; set; }
    }
}
