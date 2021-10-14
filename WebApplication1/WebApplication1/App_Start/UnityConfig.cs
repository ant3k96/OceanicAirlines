using OceanicAirlines.Application.Repos;
using OceanicAirlines.Infrastructue.Repos;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace WebApplication1
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IRouteRepo, RouteRepo>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}