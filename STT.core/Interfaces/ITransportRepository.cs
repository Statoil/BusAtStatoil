using STT.core.Model;

namespace STT.core.Interfaces
{
    public interface ITransportRepository : IRepository<Transport>
    {
        Transport GetTransportInformation(string city, string kind);
    }
}
