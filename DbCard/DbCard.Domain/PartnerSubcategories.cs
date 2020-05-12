using System;
using System.Collections.Generic;
using System.Text;

namespace DbCard.Domain
{
    public class PartnerSubcategories: Entity<long>
    {
        public long PartnerId { get; set; }
        public long SubcategoryId { get; set; }
        public virtual Partner Partner { get; set; }
        public virtual Subcategory Subcategory { get; set; }
    }
}
