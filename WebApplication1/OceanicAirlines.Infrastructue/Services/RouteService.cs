using OceanicAirlines.Application.Repos;
using OceanicAirlines.Application.Services;
using OceanicAirlines.Domain.DTOs;
using OceanicAirlines.Domain.EntityModels;
using OceanicAirlines.Infrastructue.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using Type = OceanicAirlines.Domain.EntityModels.Type;

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

                var froms = connections.Select(x => x.CityFrom).ToList();
                var tos = connections.Select(x => x.CityTo).ToList();

                var newList = _cityRepo.GetAll().ToList();

                var fromNames = connections.Select(x => x.CityFrom).Select(x => x.Name);
                var toNames = connections.Select(x => x.CityTo).Select(x => x.Name);

                var origin = _cityRepo.GetSingleByName(request.FromName);
                var destination = _cityRepo.GetSingleByName(request.ToName);

                if (origin != null && destination != null)
                {
                    request.FromName = origin.Id;
                    request.ToName = destination.Id;

                    var dijkstra = new DijkstraHelper(fromNames, toNames, newList);

                    var result = dijkstra.CountRoute(request);
                    result.FromName = _cityRepo.GetSingle(result.FromId).Name;
                    result.ToName = _cityRepo.GetSingle(result.ToId).Name;

                    return result;
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
            // Mocked
            return new Route
            {
                Id = Guid.NewGuid().ToString(),
                FromId = request.FromName,
                ToId = request.ToName,
                Date = DateTime.UtcNow,
                Duration = 32,
                PackageSize = Size.A,
                PackageType = Type.CautiousParcels,
                PackageWeight = Weight.A
            };
        }

        public Route FindFastest(FindRouteRequest request)
        {
            // Mocked
            return new Route
            {
                Id = Guid.NewGuid().ToString(),
                FromId = request.FromName,
                ToId = request.ToName,
                Date = DateTime.UtcNow,
                Duration = 32,
                PackageSize = Size.A,
                PackageType = Type.CautiousParcels,
                PackageWeight = Weight.A
            };
        }

        public IEnumerable<FindAirportRouteResponse> GetHistory()
        {
            var routes = _routeRepo.GetRouteHistory();

            var results = new List<FindAirportRouteResponse>();

            foreach(var route in routes)
            {
                results.Add(new FindAirportRouteResponse
                {
                    FromId = route.FromId,
                    ToId = route.ToId,
                    FromName = _cityRepo.GetSingle(route.FromId).Name,
                    ToName = _cityRepo.GetSingle(route.ToId).Name,
                    Type = route.PackageType.ToString(),
                    Weight = 5,
                    Duration = route.Duration,
                    Cost = 60
                });
            }

            return results;
        }

        public void Register(RegisterRouteRequest request)
        {
            var route = new Route
            {
                Id = Guid.NewGuid().ToString(),
                FromId = request.FromId,
                ToId = request.ToId,
                PackageSize = Size.A,
                PackageWeight = Weight.B,
                PackageType = Type.Weapons,
                Duration = request.Duration,
                Date = DateTime.UtcNow
            };

            _routeRepo.Add(route);
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


            var newList = _cityRepo.GetAll().ToList();

            
            var froms = connections.Select(x => x.CityFrom).Select(x => x.Name);
            var tos = connections.Select(x => x.CityTo).Select(x => x.Name);

            var dijkstra = new DijkstraHelper(froms, tos, newList);

            foreach (var req in request)
            {
                var origin = _cityRepo.GetSingleByName(req.FromName);
                var destination = _cityRepo.GetSingleByName(req.ToName);

                if (origin != null && destination != null)
                {
                    req.FromName = origin.Id;
                    req.ToName = destination.Id;

                    dijkstra.CountRoute(req);

                    var result = dijkstra.CountRoute(req);

                    result.FromName = _cityRepo.GetSingle(result.FromId).Name;
                    result.ToName = _cityRepo.GetSingle(result.ToId).Name;

                    list.Add(result);
                }
                
            }
        }
    }
}
