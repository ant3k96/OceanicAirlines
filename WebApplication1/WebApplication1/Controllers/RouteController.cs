using OceanicAirlines.Application.Services;
using OceanicAirlines.Domain.DTOs;
using OceanicAirlines.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
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

        public IEnumerable<Route> GetHistory()
        {
            return _routeService.GetHistory();
        }

        public void Register(Route route)
        {
            _routeService.Register(route);
        }
    }
}