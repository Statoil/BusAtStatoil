using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace STT.core.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetAllReadOnly();

        T GetById(int id);

        void SaveOrUpdate(T entity);

        void Delete(T entity);

        IEnumerable<T> Find(Expression<Func<T, bool>> expression, int maxHits = 100);


        void Saveall();
    }
}