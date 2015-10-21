using Microsoft.Practices.Unity;
using System.Web.Http;
using GymHub.DataAccess.Infrastructure;
using GymHub.Service;
using Unity.WebApi;

namespace GymHub.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IAthleteService, AthleteService>();
            container.RegisterType<IStatisticsService, StatisticsService>();
            container.RegisterType<IAttachmentService, AttachmentService>();
            container.RegisterType<IDietService, DietService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);


        }
    }
}