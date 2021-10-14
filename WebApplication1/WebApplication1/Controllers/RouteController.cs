using OceanicAirlines.Application.Services;
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