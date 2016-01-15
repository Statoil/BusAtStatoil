using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STT.core.Interfaces;
using STT.core.Interfaces.Services;
using STT.core.Model;

namespace STT.service.Services
{
    public class OfficeLocationService : BaseService<OfficeLocation>, IOfficeLocationService
    {
        protected new IOfficeLocationRepository Repository;

        public OfficeLocationService(IUnitOfWork unitOfWork, IOfficeLocationRepository officeLocationRepository)
            : base(unitOfWork)
        {
            base.Repository = officeLocationRepository;
        }

        public void InitData(IEnumerable<OfficeLocation> data)
        {
            foreach (var ol in data)
            {
                base.SaveOrUpdate(ol);
            }
        }

        public IList<OfficeLocation> GetOfficeLocations()
        {
            return base.GetAllReadOnly().ToList();
            //return _officeList.ToList();
        }

        public IList<string> GetOfficeCities()
        {
            return GetOfficeLocations().AsQueryable()
                .OrderBy(c => c.City)
                .Select(c => c.City).Distinct()
                .ToList();
        }


        public IList<OfficeLocation> GetOfficesByCity(string city)
        {
            return GetOfficeLocations().AsQueryable()
                .Where(c => c.City == city)
                .OrderBy(n => n.Name + " (" + n.Code + ")")
                //.Select(n => n.Name).Distinct()
                .ToList();
        }

        public IList<OfficeLocation> GetOfficesByCode(string code)
        {
            return GetOfficeLocations().AsQueryable()
                .Where(c => c.Code.StartsWith(code))
                //.OrderBy(n => n.Name + " (" + n.Code + ")")
                //.Select(n => n.Name).Distinct()
                .ToList();
        }
        



    }
}
