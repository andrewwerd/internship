using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T item);
        T GetById(int Id);
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
        public void Add(T item)
        {
            if (_context.Count > 0)
                item.ID = _context.Last().ID + 1;
            _context.Add(item);

        }
        public void Delete(T item)
        {
            _context.Remove(item);
        }
        public T GetById(int id)
        {
            T item = _context.Find(x => x.ID == id);
            return item;
        }
        public IEnumerable<T> GetAll()
        {
            return _context;
        }
        public void Update(T item)
        {
            var current = _context.FirstOrDefault(x => x.ID == item.ID);
            current = item;
        }
    }
}
