using Autofac;
using Autofac.Integration.WebApi;
using CourseViewer.Data.Interfaces;
using CourseViewer.Data.Repositories;
using CourseViewerWebApi.Controllers;
using CourseViewerWebApi.DAL;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CourseViewerWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ContainerBuilder builder = new ContainerBuilder();

            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //    .Where(t => (t.Name.EndsWith("Controller"))).InstancePerRequest();

            builder.RegisterType<AccountController>().InstancePerRequest();
            builder.RegisterType<CourseViewerApiController>().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(AuthorRepository).Assembly)
                .Where(t => (t.Name.EndsWith("Repository")))
                .As(t => t.GetInterfaces().FirstOrDefault(
                    i => i.Name == "I" + t.Name));

            builder.RegisterType<DataRepositoryFactory>().As<IDataRepositoryFactory>();

            IContainer container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
