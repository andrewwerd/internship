using System.Linq.Expressions;
using Domain;
using WebApi.Infrastructure.Models;

namespace WebApi.Services
{
    public interface IRepository<TEntity> where TEntity : Entity<long>
    {
        IQueryable<TEntity> Get();
        Task<TEntity> Add(TEntity item);
        Task<TEntity> GetById(long id);
        Task<TEntity> GetByIdWithInclude(long id, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<IEnumerable<TEntity>> GetByPredicate(Expression<Func<TEntity, bool>> p);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Delete(long id);
        Task<TEntity> Delete(TEntity entity);
        Task<TEntity> Update(TEntity item);
        Task<bool> SaveAll();
        bool Any(Expression<Func<TEntity, bool>> p);
        Task<PaginatedResult<TDto>> GetPagedData<TDto>(PagedRequest pagedRequest, Expression<Func<TEntity, bool>> expression = null) where TDto : class;
        Task<IEnumerable<TDto>> GetScrollData<TDto>(PagedRequest scrollRequest, Expression<Func<TEntity, bool>> expression = null) where TDto : class;
    }

}
