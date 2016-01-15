using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using STT.core.Interfaces.Services;
using STT.service.Services;

namespace STT.worker
{
    class WorkerModule: NinjectModule
    {
        public override void Load()
        {
            //Bind<ILocationService>().To<LocationService>().InRequestScope();
            //Bind<IOfficeLocationService>().To<OfficeLocationService>().InRequestScope();
        }
    }
}
