using System.Linq;
using STT.core.Interfaces;
using STT.core.Model;

namespace STT.data.Repository
{
    public class OfficeLocationRepository : BaseRepository<OfficeLocation>, IOfficeLocationRepository
    {
        public OfficeLocationRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }

        public OfficeLocation GetByName(string name)
        {
            return base.GetAll().Where(x => x.Name == name).Select(x => x).ToList().FirstOrDefault();
        }
    }
        
}
