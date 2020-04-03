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
    }
}
