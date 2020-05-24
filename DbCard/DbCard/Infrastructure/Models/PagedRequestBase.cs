using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.Models
{
    public abstract class PagedRequestBase
    {
        public PagedRequestBase()
        {
            RequestFilters = new RequestFilters();
        }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public RequestFilters RequestFilters { get; set; }
    }
}
