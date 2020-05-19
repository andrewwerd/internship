using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.Models
{
    public class Filter
    {
        public string Path { get; set; }
        public string Value { get; set; }
    }
    public enum FilterLogicalOperators
    {
        And,
        Or,
    }
}
