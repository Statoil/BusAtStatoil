using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel;

namespace STT.core.Interfaces.Services
{
    [ServiceContract]
    public interface IService<T>
    {
        [OperationContract]
        IQueryable<T> GetAll();
        
        /*
        [OperationContract]
        IQueryable<T> GetAllReadOnly();

        [OperationContract]
        T GetById(int id);

        [OperationContract]
        void SaveOrUpdate(T entity);

        [OperationContract]
        void Delete(T entity);

        [OperationContract]
        IEnumerable<T> Find(Expression<Func<T, bool>> expression, int maxHits = 100);*/
    }
}
