using OceanicAirlines.Application.Services;
using OceanicAirlines.Domain.DTOs;
using OceanicAirlines.Domain.EntityModels;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RouteController : ApiController
    {
        private readonly IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }
        public Route FindCheapest(FindRouteRequest request)
        {
            return _routeService.FindCheapest(request);
        }

        public Route FindFastest(FindRouteRequest request)
        {
            return _routeService.FindFastest(request);
        }
        
        public FindAirportRouteResponse FindAirportsRoute(FindRouteRequest request)
        {
            return _routeService.FindAirportsRoute(request);
        }

        public IEnumerable<FindAirportRouteResponse> FindAirportsRoutes(IEnumerable<FindRouteRequest> requests)
        {
            return _routeService.FindAirportsRoute(requests);
        }

        public IEnumerable<FindAirportRouteResponse> GetHistory()
        {
            return _routeService.GetHistory();
        }

        public void Register(RegisterRouteRequest route)
        {
            _routeService.Register(route);
        }
    }
}