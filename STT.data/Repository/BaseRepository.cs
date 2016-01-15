using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using STT.core.Interfaces;
using STT.core.Model;

namespace STT.data.Repository
{
    public abstract class BaseRepository<T> : IDisposable, IRepository<T> where T : BaseEntity
    {
        private IDataContext _context;
        private readonly IDbSet<T> _dbset;
        private readonly IDatabaseFactory _databaseFactory;

        protected BaseRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
            _context = _databaseFactory.Get();
            _dbset = DataContext.DbSet<T>();
        }

        public IDataContext DataContext
        {
            get { return _context ?? (_context = _databaseFactory.Get()); }
        }

        protected string EntitySetName { get; set; }

      public virtual void SaveOrUpdate(T entity)
        {
            if (UnitOfWork.IsPersistent(entity))
            {
                DataContext.Entry(entity).State = EntityState.Modified;
                entity.Updated = DateTime.Now;
            }
            else
            {
                entity.Created = DateTime.Now;
                entity.Updated = DateTime.Now;
                _dbset.Add(entity);
            }
            DataContext.ObjectContext().SaveChanges();

        }

        public virtual void Saveall()
        {
            DataContext.ObjectContext().SaveChanges();
        }


        public virtual T GetById(int id)
        {
            return _dbset.Find(id);
        }

    

        public virtual IQueryable<T> GetAll()
        {
            return _dbset;
        }

        public virtual IQueryable<T> GetAllReadOnly()
        {
            return _dbset.AsNoTracking();
        }

        public virtual void Delete(T entity)
        {
            _dbset.Remove(entity);
            DataContext.ObjectContext().SaveChanges();
        }

        public virtual IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> expression, int maxHits = 100)
        {
            return _dbset.Where(expression).Take(maxHits);
        }

        public void Dispose()
        {
            DataContext.ObjectContext().Dispose();
        }
    }
}