using System.Collections.Generic;

namespace DbCard.Models.Charts
{
    public class ChartData<T>
    {
        public IEnumerable<string> Labels { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
