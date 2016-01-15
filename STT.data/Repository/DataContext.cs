using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using STT.core.Model;
using STT.core.Interfaces;


namespace STT.data.Repository
{
    public class DataContext : DbContext, IDataContext 
    {
        public DataContext()
            : this(true)
        {
        }

        public DataContext(bool proxyCreation = true)
            : base("name=STT")
        {
            Configuration.ProxyCreationEnabled = proxyCreation;
        }

        #region IDataContext Members

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transport>().HasKey(t => new
            {
                t.City,
                t.Kind
            });
        }*/

        public ObjectContext ObjectContext()
        {
            return ((IObjectContextAdapter)this).ObjectContext;
        }

        public virtual IDbSet<T> DbSet<T>() where T : BaseEntity
        {
            return Set<T>();
        }

        public new DbEntityEntry Entry<T>(T entity) where T : BaseEntity
        {
            return base.Entry(entity);
        }

        #endregion

        public DbSet<OfficeLocation> OfficeLocations { get; set; }

        public DbSet<Transport> Transport { get; set; }

        public DbSet<Article> Article { get; set; }


    }
}
