using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GymHub
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["GymHubDBContext"].ConnectionString;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();

            //Start SqlDependency with application initialization
            var entityConnectionStringBuilder = new EntityConnectionStringBuilder(_connectionString);
            var providerConnectionString = entityConnectionStringBuilder.ProviderConnectionString;
            SqlDependency.Start(providerConnectionString);
        }

        protected void Application_End()
        {
            //Free the dependency
            SqlDependency.Stop(_connectionString);
        }
    }
}
