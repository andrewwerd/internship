using System;
using System.Collections.Generic;
using System.Linq;
using Proiect.Models;

namespace Proiect.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private List<T> _context;
        private static readonly Lazy<Repository<T>> lazy = new Lazy<Repository<T>>(() => new Repository<T>(), true);

        public static Repository<T> Instance => lazy.Value;

        private Repository()
        {
            _context = new List<T>();
        }

        public void Add(T item)
        {
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

        internal object First(Guid partnerId)
        {
            throw new NotImplementedException();
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
