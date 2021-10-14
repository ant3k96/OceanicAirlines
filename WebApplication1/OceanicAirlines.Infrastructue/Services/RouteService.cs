using OceanicAirlines.Application.Repos;
using OceanicAirlines.Application.Services;
using OceanicAirlines.Domain.DTOs;
using OceanicAirlines.Domain.EntityModels;
using OceanicAirlines.Infrastructue.Helpers;
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
        private readonly ICityRepo _cityRepo;

        public RouteService(IRouteRepo routeRepo, ICityRepo cityRepo)
        {
            _routeRepo = routeRepo;
            _cityRepo = cityRepo;
        }

        public FindAirportRouteResponse FindAirportsRoute(FindRouteRequest request)
        {
            try
            {
                var connections = _cityRepo.GetConnections();
                var froms = connections.Select(x => x.CityFrom).Select(x => x.Name);
                var tos = connections.Select(x => x.CityTo).Select(x => x.Name);

                var origin = _cityRepo.GetSingleByName(request.FromId);
                var destination = _cityRepo.GetSingleByName(request.ToId);

                if (origin != null && destination != null)
                {
                    request.FromId = origin.Id;
                    request.ToId = destination.Id;

                    var dijkstra = new DijkstraHelper(froms, tos);

                    return dijkstra.CountRoute(request);
                }

                return null;
                
            }
            catch
            {
                return null;
            }
            
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

        public IEnumerable<FindAirportRouteResponse> FindAirportsRoute(IEnumerable<FindRouteRequest> request)
        {
            try
            {
                var list = new List<FindAirportRouteResponse>();
                CountForAll(request, list);
                return list;
            }
            catch
            {
                return null;
            }
        }

        private void CountForAll(IEnumerable<FindRouteRequest> request, List<FindAirportRouteResponse> list)
        {
            var connections = _cityRepo.GetConnections();
            var froms = connections.Select(x => x.CityFrom).Select(x => x.Name);
            var tos = connections.Select(x => x.CityTo).Select(x => x.Name);

            var dijkstra = new DijkstraHelper(froms, tos);

            foreach (var req in request)
            {
                var origin = _cityRepo.GetSingleByName(req.FromId);
                var destination = _cityRepo.GetSingleByName(req.ToId);

                if (origin != null && destination != null)
                {
                    req.FromId = origin.Id;
                    req.ToId = destination.Id;

                    dijkstra.CountRoute(req);

                    var result = dijkstra.CountRoute(req);
                    list.Add(result);
                }
                
            }
        }
    }
}
