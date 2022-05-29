namespace WebApi.Models.Charts
{
    public class ChartData<T>
    {
        public IEnumerable<string> Labels { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
