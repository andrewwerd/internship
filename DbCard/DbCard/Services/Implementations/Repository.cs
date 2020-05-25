using AutoMapper;
using DbCard.Context;
using DbCard.Domain;
using DbCard.Infrastructure.Extensions;
using DbCard.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DbCard.Services
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
        public IQueryable<TEntity> Get()
        {
            return _context.Set<TEntity>().AsQueryable();
        }
        public async Task<TEntity> Delete(long id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null)
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
        public async Task<IEnumerable<TEntity>> GetByPredicate(Expression<Func<TEntity, bool>> p)
        {
            return await _context.Set<TEntity>().Where(p).ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(long id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetByIdWithInclude(long id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = IncludeProperties(includeProperties);
            return await query.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task<PaginatedResult<TDto>> GetPagedData<TDto>(PagedRequest pagedRequest, Expression<Func<TEntity, bool>> optionalPredicate = null) where TDto : class
        {
            return await _context.Set<TEntity>().CreatePaginatedResultAsync<TEntity, TDto>(pagedRequest, _mapper, optionalPredicate);
        }
        public async Task<IEnumerable<TDto>> GetScrollData<TDto>(PagedRequest scrollRequest, Expression<Func<TEntity, bool>> optionalPredicate = null) where TDto : class
        {
            return await _context.Set<TEntity>().CreateScrollPaginatedResultAsync<TEntity, TDto>(scrollRequest, _mapper, optionalPredicate);
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
        public bool Any(Expression<Func<TEntity, bool>> p)
        {
            return _context.Set<TEntity>().Any(p);
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
