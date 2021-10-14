using OceanicAirlines.Application.Repos;
using OceanicAirlines.Domain.EntityModels;
using System;
using System.Collections.Generic;

namespace OceanicAirlines.Infrastructue.Repos
{
    public class RouteRepo : IRouteRepo
    {
        public RouteRepo()
        {
        }

        public void Add(Route route)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Route> GetRouteHistory()
        {
            throw new NotImplementedException();
        }

        public Route GetSingle(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
