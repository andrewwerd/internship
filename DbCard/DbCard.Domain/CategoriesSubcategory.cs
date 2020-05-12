using System;
using System.Collections.Generic;
using System.Text;

namespace DbCard.Domain
{
    public class CategoriesSubcategory: Entity<long>
    {
        public long CategoryId { get; set; }
        public long SubcategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Subcategory Subcategory { get; set; }
    }
}
