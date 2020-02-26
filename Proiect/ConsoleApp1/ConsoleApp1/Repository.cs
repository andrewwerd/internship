using System;
using System.Collections.Generic;
using System.Linq;

namespace Proiect
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T item);
        T GetById(Guid Id);
        IEnumerable<T> GetAll();
        void Delete(T item);
        void Update(T item);
    }

    public class Repository<T> : IRepository<T> where T : Entity
    {
        public List<T> _context;
        public Repository()
        {
            _context = new List<T>();
        }
        public virtual void Add(T item)
        {
            item.Id = Guid.NewGuid();
            _context.Add(item);

        }
        public void Delete(T item)
        {
            _context.Remove(item);
        }
        public T GetById(Guid id)
        {
            T item = _context.Find(x => x.Id == id);
            return item;
        }
        public IEnumerable<T> GetAll()
        {
            return _context;
        }
        public List<T> ToList()
        {
            return _context;
        }
        public void Update(T item)
        {
            var current = _context.FirstOrDefault(x => x.Id == item.Id);
            current = item;
        }
    }
}
