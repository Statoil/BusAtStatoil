using STT.core.Model;

namespace STT.core.Interfaces
{
    public interface IOfficeLocationRepository : IRepository<OfficeLocation>
    {
        OfficeLocation GetByName(string name);
    }
}
