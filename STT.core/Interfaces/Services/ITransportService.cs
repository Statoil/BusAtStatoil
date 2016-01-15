using System.Collections.Generic;
using STT.core.Model;

namespace STT.core.Interfaces.Services
{
    public interface ITransportService : IService<Transport>
    {
        IList<Transport> GetTransportInformation(string city, string kind);
        Transport UpdateTransportService(string city, string kind, string info, string moreinfo);
        void InitData(IEnumerable<Transport> enumerable);
    }
}
