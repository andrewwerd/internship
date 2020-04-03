using System.Linq;

namespace dbCard.Context
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Page<T>(this IOrderedQueryable<T> query, int page = 1, int pageSize = 10)
        {
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
