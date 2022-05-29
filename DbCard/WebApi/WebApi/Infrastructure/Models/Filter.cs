namespace WebApi.Infrastructure.Models
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
