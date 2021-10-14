using OceanicAirlines.Application.Repos;
using OceanicAirlines.Application.Services;
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
        public Route FindCheapest()
        {
            throw new NotImplementedException();
        }

        public Route FindFastest()
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
