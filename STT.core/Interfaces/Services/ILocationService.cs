using System.Collections.Generic;
using STT.core.Model;

namespace STT.core.Interfaces.Services
{
    public interface ILocationService : IService<Location>
    {
        //void UpdateLocations();
        IList<Location> GetLocations();
    }
}
