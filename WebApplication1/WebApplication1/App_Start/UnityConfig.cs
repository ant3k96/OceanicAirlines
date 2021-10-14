using OceanicAirlines.Application.Repos;
using OceanicAirlines.Application.Services;
using OceanicAirlines.Infrastructue.Repos;
using OceanicAirlines.Infrastructue.Services;
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
            container.RegisterType<ICityRepo, CityRepo>();
            container.RegisterType<IRouteService, RouteService>();
            container.RegisterType<ICityService, CityService>();
            
            GlobalConfiguration.Configuration.DependencyResolver 
                = new UnityDependencyResolver(container);
        }
    }
}