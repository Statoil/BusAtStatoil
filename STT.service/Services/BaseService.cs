using System;
using System.Collections.Generic;
using System.Linq;
using STT.core.Interfaces;
using STT.core.Interfaces.Services;
using STT.core.Model;

namespace STT.service.Services
{
    public abstract class BaseService<T> : IService<T> where T : BaseEntity
    {
        protected IRepository<T> Repository;

        protected IUnitOfWork UnitOfWork;

        protected BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public virtual IQueryable<T> GetAll()
        {
            return Repository.GetAll();
        }

        public virtual IQueryable<T> GetAllReadOnly()
        {
            return Repository.GetAllReadOnly();
        }

        public virtual T GetById(int id)
        {
            return Repository.GetById(id);
        }

        public virtual void SaveOrUpdate(T entity)
        {
            Repository.SaveOrUpdate(entity);
            //UnitOfWork.Commit();
        }

        public virtual void Delete(T entity)
        {
            Repository.Delete(entity);
            UnitOfWork.Commit();
        }

        public virtual IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> expression, int maxHits = 100)
        {
            return Repository.Find(expression, maxHits);
        }

        public void Saveall()
        {
            Repository.Saveall();
        }
    }
}
