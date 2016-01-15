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
    public class TransportService : BaseService<Transport>, ITransportService
    {
        protected new ITransportRepository Repository;

        public TransportService(IUnitOfWork unitOfWork, ITransportRepository transportRepository)
            : base(unitOfWork)
        {
            base.Repository = transportRepository;
        }

        public void InitData(IEnumerable<Transport> data)
        {
            foreach (var t in data)
            {
                base.SaveOrUpdate(t);
            }
        }

        public IList<Transport> GetTransportInformation(string city, string kind)
        {
            return base.GetAllReadOnly()
                .Where(c => c.City == city)
                .Where(k => k.Kind == kind).ToList();
            //return _officeList.ToList();
        }

        public Transport UpdateTransportService(string city, string kind, string info, string moreinfo)
        {
            Transport t = base.GetAll()
                .Where(c => c.City == city)
                .Where(k => k.Kind == kind).FirstOrDefault();
            
            if (t == null)
            {
                t = new Transport();
                t.City = city;
                t.Kind = kind;
            }
            
            t.Information = info;
            t.Moreinformation = moreinfo;
            base.SaveOrUpdate(t);
            return t;
        }
    }
}
