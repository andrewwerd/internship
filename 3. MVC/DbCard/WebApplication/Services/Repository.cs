using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<long>
    {
        DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
        }
        public void Add(TEntity item)
        {
            _context.Set<TEntity>().Add(item);
            _context.SaveChanges();
        }
        public void Remove(TEntity item)
        {
            _context.Set<TEntity>().Remove(item);
            _context.SaveChanges();
        }
        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public TEntity FindById(long id)
        {
            return _context.Set<TEntity>().Find(id);
        }
        public IEnumerable<TEntity> Get()
        {
            return _context.Set<TEntity>().AsNoTracking().ToList();
        }
        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().AsNoTracking().Where(predicate).ToList();
        }
        public async Task AddAsync(TEntity item)
        {
            _context.Set<TEntity>().Add(item);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(TEntity item)
        {
            _context.Set<TEntity>().Remove(item);
             await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<TEntity> FindByIdAsync(long id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }
    }
}
