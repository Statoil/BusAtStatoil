using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STT.core.Interfaces.Services;
using STT.core.Model;

namespace STT.service.Services
{
    public class LocationService : ILocationService
    {

        public IList<Location> GetLocations()
        {
            Location loc = new Location();         // dummy data   
            loc.Name = "Testem"; 
            loc.Lat = 12; loc.Lon = 1.0;
            loc.Id = 1;
            List<Location> ll = new List<Location>();
            ll.Add(loc);
            return ll;
        }

        IQueryable<STT.core.Model.Location> IService<STT.core.Model.Location>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
