using System.Collections.Generic;
using STT.core.Model;

namespace STT.core.Interfaces.Services
{
    public interface IOfficeLocationService : IService<OfficeLocation>
    {
        //void UpdateLocations();
        IList<OfficeLocation> GetOfficeLocations();

        IList<string> GetOfficeCities();

        IList<OfficeLocation> GetOfficesByCity(string city);

        IList<OfficeLocation> GetOfficesByCode(string code);

        void InitData(IEnumerable<OfficeLocation> enumerable);
    }
}
