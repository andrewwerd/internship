using System;
using System.Collections.Generic;
using Proiect.Models;

namespace Proiect.Repository
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T item);
        T GetById(Guid Id);
        IEnumerable<T> GetAll();
        void Delete(T item);
        void Update(T item);
    }

}
