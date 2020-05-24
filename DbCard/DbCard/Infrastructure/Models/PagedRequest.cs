using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.Models
{
    public class PagedRequest: PagedRequestBase
    {
        public string ColumnNameForSorting { get; set; }

        public string SortDirection { get; set; }

    }
}
