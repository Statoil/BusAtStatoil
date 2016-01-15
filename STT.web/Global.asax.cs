using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Mvc;
using STT.core.Interfaces;
using STT.core.Interfaces.Services;
using STT.data.Repository;
using STT.service.Services;

namespace STT.web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : NinjectHttpApplication //System.Web.HttpApplication
    {
        /*protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }*/
        
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
        }


        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

        }


        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            //kernel.Load(Assembly.GetExecutingAssembly(),Assembly.Load(STT.
            kernel.Bind<IDatabaseFactory>().To<DatabaseFactory>().InRequestScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<IOfficeLocationRepository>().To<OfficeLocationRepository>().InRequestScope();
            kernel.Bind<IOfficeLocationService>().To<OfficeLocationService>().InRequestScope();
            kernel.Bind<ITransportRepository>().To<TransportRepository>().InRequestScope();
            kernel.Bind<ITransportService>().To<TransportService>().InRequestScope();
            kernel.Bind<IArticleRepository>().To<ArticleRepository>().InRequestScope();
            kernel.Bind<IArticleService>().To<ArticleService>().InRequestScope();
            //kernel.Bind<ILocationService>().To<LocationService>().InRequestScope();            
            //RegisterServices(kernel);
            return kernel;
        }

    }
}