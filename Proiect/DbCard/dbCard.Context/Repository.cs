using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using dbCard.Domain.Models;

namespace dbCard.Context
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<long>
    {
        DbContext _context;
        DbSet<TEntity> _dbSet;
        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }
        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }
        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public TEntity FindById(long id)
        {
            return _dbSet.Find(id);
        }
        public IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }
        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }
    }
}
