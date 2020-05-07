using DbCard.Domain;
using DbCard.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DbCard.Repository
{
    public interface IRepository<TEntity> where TEntity : Entity<long>
    {
        Task<TEntity> Add(TEntity item);
        Task<TEntity> GetById(long id);
        Task<TEntity> GetByIdWithInclude(long id, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<IEnumerable<TEntity>> GetByPredicate(Func<TEntity, bool> p);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Delete(long id); 
        Task<TEntity> Delete(TEntity entity);
        Task<TEntity> Update(TEntity item);
        Task<bool> SaveAll();
        Task<PaginatedResult<TDto>> GetPagedData<TDto>(PagedRequest pagedRequest) where TDto : class;
    }

}
