using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using TaxReturn.ApplicationServices;
using TaxReturn.Core;
using TaxReturn.Repository;
using TaxReturn.Repository.Interfaces;

namespace TaxReturn
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<UploadFileContentService>().As<IUploadFileContentService>();
            builder.RegisterType<RepositoryFactory>().As<IRepositoryFactory>();
            builder.RegisterType<QueryAccountTransaction>().As<IQueryAccountTransaction>();
            builder.RegisterControllers(typeof (MvcApplication).Assembly).InstancePerRequest();
            
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
