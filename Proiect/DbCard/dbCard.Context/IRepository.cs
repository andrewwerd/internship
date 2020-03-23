using dbCard.Domain;
using System;
using System.Collections.Generic;


namespace dbCard.Context
{
    public interface IRepository<TEntity> where TEntity : Entity <long>
    {
        void Add(TEntity item);
        TEntity FindById(long Id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void Remove(TEntity item);
        void Update(TEntity item);
    }

}
