using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using STT.core.Interfaces;
using STT.core.Model;

namespace STT.data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDataContext _datacontext;

        private readonly IDatabaseFactory _databaseFactory;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this._databaseFactory = databaseFactory;
            this.DataContext.ObjectContext().SavingChanges += (sender, e) => BeforeSave(this.GetChangedOrNewEntities());
        }

        public IDataContext DataContext
        {
            get { return this._datacontext ?? (this._datacontext = this._databaseFactory.Get()); }
        }

        /// <summary>
        /// Extracts new or changed entities and return them as PersistenEntities.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<BaseEntity> GetChangedOrNewEntities()
        {
            const EntityState newOrModified = EntityState.Added | EntityState.Modified;

            return this.DataContext.ObjectContext().ObjectStateManager.GetObjectStateEntries(newOrModified)
                .Where(x => x.Entity != null).Select(x => x.Entity as BaseEntity);
        }

        /// <summary>
        /// Before save, we will set the updated and created time.
        /// We do this in save or update, but here we can reach all children that may have been edited/created.
        /// In saveOrUpdate it´s only the current entity getting accessed...
        /// </summary>
        /// <param name="entities"></param>
        public void BeforeSave(IEnumerable<BaseEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.Updated = DateTime.Now;
                entity.Created = !IsPersistent(entity) ? DateTime.Now : entity.Created;
            }
        }

        public static bool IsPersistent(BaseEntity entity)
        {
            return entity.Id != 0;
        }

        public int Commit()
        {
            return this.DataContext.ObjectContext().SaveChanges();
        }
    }
}
