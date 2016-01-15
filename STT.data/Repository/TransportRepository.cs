using System.Linq;
using STT.core.Interfaces;
using STT.core.Model;

namespace STT.data.Repository
{
    public class TransportRepository : BaseRepository<Transport>, ITransportRepository
    {
        public TransportRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }

        public Transport GetTransportInformation(string city, string kind)
        {
            return base.GetAll().Where(x => x.City == city).Select(x => x).ToList().FirstOrDefault();
        }
    }
        
}
