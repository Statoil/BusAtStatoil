using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using STT.core.Model;

namespace STT.core.Interfaces
{
    public interface IDataContext
    {
        ObjectContext ObjectContext();
        IDbSet<T> DbSet<T>() where T : BaseEntity;
        DbEntityEntry Entry<T>(T entity) where T : BaseEntity;
        void Dispose();
    }
}
