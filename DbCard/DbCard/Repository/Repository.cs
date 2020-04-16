using AutoMapper;
using DbCard.Context;
using DbCard.Domain;
using DbCard.Infrastructure.Extensions;
using DbCard.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DbCard.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<long>
    {
        readonly DbCardContext _context;
        readonly IMapper _mapper;
        public Repository(DbCardContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TEntity> Add(TEntity item)
        {
            _context.Set<TEntity>().Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<TEntity> Delete(long id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if(entity == null)
            {
                throw new Exception($"Object of type {typeof(TEntity)} with id { id } not found");
            }
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<TEntity> Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public TEntity GetByPredicate(Func<TEntity, bool>p)
        {
            return  _context.Set<TEntity>().FirstOrDefault(p);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(long id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetByIdWithInclude(int id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = IncludeProperties(includeProperties);
            return await query.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task<PaginatedResult<TDto>> GetPagedData<TDto>(PagedRequest pagedRequest) where TDto : class
        {
            return await _context.Set<TEntity>().CreatePaginatedResultAsync<TEntity, TDto>(pagedRequest, _mapper);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task<TEntity> Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return item;
        }
        private IQueryable<TEntity> IncludeProperties(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> entities = _context.Set<TEntity>();
            foreach (var includeProperty in includeProperties)
            {
                entities = entities.Include(includeProperty);
            }
            return entities;
        }
    }
}
