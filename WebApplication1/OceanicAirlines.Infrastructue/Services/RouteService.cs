using OceanicAirlines.Application.Repos;
using OceanicAirlines.Application.Services;
using OceanicAirlines.Domain.DTOs;
using OceanicAirlines.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanicAirlines.Infrastructue.Services
{
    public class RouteService : IRouteService
    {
        private readonly IRouteRepo _routeRepo;

        public RouteService(IRouteRepo routeRepo)
        {
            _routeRepo = routeRepo;
        }

        public FindAirportRouteResponse FindAirportsRoute(FindRouteRequest request)
        {
            throw new NotImplementedException();
        }

        public Route FindCheapest(FindRouteRequest request)
        {
            throw new NotImplementedException();
        }

        public Route FindFastest(FindRouteRequest request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Route> GetHistory()
        {
            throw new NotImplementedException();
        }

        public void Register(Route route)
        {
            throw new NotImplementedException();
        }
    }
}
