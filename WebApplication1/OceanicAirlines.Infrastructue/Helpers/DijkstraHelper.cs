using OceanicAirlines.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;
using System.Reflection;
using OceanicAirlines.Domain.EntityModels;

namespace OceanicAirlines.Infrastructue.Helpers
{
    public class DijkstraHelper
    {
        private readonly IEnumerable<string> froms;
        private readonly IEnumerable<string> tos;
        private readonly List<City> cities;

        public DijkstraHelper(IEnumerable<string> froms, IEnumerable<string> tos, List<City> cities)
        {
            this.froms = froms;
            this.tos = tos;
            this.cities = cities;
        }

        public FindAirportRouteResponse CountRoute(FindRouteRequest request)
        {
            var graph = GetGraph("airplane");

            return GetResult(graph, request);
        }
        
        private FindAirportRouteResponse GetResult(Graph givenGraph, FindRouteRequest request)
        {
            var graph = new Graph<int, string>();

            var cityNames = GetCitiesNames(givenGraph);

            AddNodesToGraph(graph, cityNames);

            CreateConnectionsBetweenNodes(givenGraph, graph, cityNames);

            var path = ProcessDijkstraAlgorithm(request, graph);

            var airportResult = GetFormattedResult(graph, path);
            airportResult.Cost = CountCost(request.Weight);
            airportResult.Type = request.Type;
            airportResult.Weight = request.Weight;

            return airportResult;
        }

        private int CountCost(double weight)
        {
            if (weight < 1)
            {
                return 40;
            } 
            else if (1 <= weight && weight <= 5) 
            {
                return 60;
            } 
            else
            {
                return 80;
            }
        }

        private FindAirportRouteResponse GetFormattedResult(Graph<int, string> graph, IEnumerable<uint> path)
        {
            var duration = (path.Count() - 1) * 8;
            var airportResult = new FindAirportRouteResponse
            {
                Duration = duration,
                FromId = (path.ElementAt(0)-1).ToString(),
                ToId = (path.ElementAt(path.Count() - 1)-1).ToString()
            };
            return airportResult;
        }

        private IEnumerable<uint> ProcessDijkstraAlgorithm(FindRouteRequest request, Graph<int, string> graph)
        {
            var result = graph.Dijkstra(uint.Parse(request.FromName) + 1, uint.Parse(request.ToName) + 1);

            var path = result.GetPath();
            return path;
        }

        private void CreateConnectionsBetweenNodes(Graph givenGraph, Graph<int, string> graph, List<string> union)
        {
            foreach (var row in givenGraph.Rows)
            {
                var indexFrom = uint.Parse(cities.FirstOrDefault(x => x.Name == row.From).Id) + 1;
                var indexTo = uint.Parse(cities.FirstOrDefault(x => x.Name == row.To).Id) + 1;

                var isFromBlacklisted = cities.First(x => x.Name == row.From).IsBlacklisted;
                var isToBlacklisted = cities.First(x => x.Name == row.To).IsBlacklisted;

                if (!isFromBlacklisted && !isToBlacklisted)
                {
                    graph.Connect(indexFrom, indexTo, (int)row.Weight, givenGraph.VehicleType);
                    graph.Connect(indexTo, indexFrom, (int)row.Weight, givenGraph.VehicleType);
                }
                
            }
        }

        private void AddNodesToGraph(Graph<int, string> graph, List<string> union)
        {
            foreach (var key in union)
            {
                var id = union.IndexOf(key);
                graph.AddNode(id);
            }
        }

        private List<string> GetCitiesNames(Graph givenGraph)
        {
            var froms = givenGraph.Rows.Select(x => x.From).ToList().Distinct();
            var tos = givenGraph.Rows.Select(x => x.To).ToList().Distinct();

            var union = froms.Concat(tos).Distinct().ToList();
            return union;
        }

        private Graph GetGraph(string vehicleType)
        {
            List<SingleConnection> list = new List<SingleConnection>();

            CreateConnections(list);

            return new Graph
            {
                Rows = list,
                VehicleType = vehicleType
            };
        }

        private void CreateConnections(List<SingleConnection> list)
        {
            for (int i = 0; i < this.froms.Count(); i++)
            {
                list.Add(new SingleConnection
                {
                    From = this.froms.ElementAt(i),
                    To = this.tos.ElementAt(i),
                    Weight = 1
                });
            }
        }
    }
}
