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

namespace OceanicAirlines.Infrastructue.Helpers
{
    public class DijkstraHelper
    {

        public static FindAirportRouteResponse CountRoute(FindRouteRequest request)
        {
            var graph = ReadFile("airplane");

            return GetDefaultDict(graph, request);

        }
        
        private static FindAirportRouteResponse GetDefaultDict(Graph givenGraph, FindRouteRequest request)
        {
            var graph = new Graph<int, string>();

            var froms = givenGraph.Rows.Select(x => x.From).ToList().Distinct();
            var tos = givenGraph.Rows.Select(x => x.To).ToList().Distinct();

            var union = froms.Concat(tos).Distinct().ToList();

            foreach (var key in union)
            {
                var id = union.IndexOf(key);
                graph.AddNode(id);
            }

            foreach(var row in givenGraph.Rows)
            {
                var indexFrom = (uint)union.IndexOf(row.From) + 1;
                var indexTo = (uint)union.IndexOf(row.To) + 1;
                graph.Connect(indexFrom, indexTo, (int)row.Weight, givenGraph.VehicleType);
                graph.Connect(indexTo, indexFrom, (int)row.Weight, givenGraph.VehicleType);
            }

            var result = graph.Dijkstra(uint.Parse(request.FromId) + 1, uint.Parse(request.ToId) + 1);

            var path = result.GetPath();

            var duration = (path.Count() - 1)  * 8;
            var cost = 420;
            var airportResult = new FindAirportRouteResponse
            {
                Duration = duration,
                Cost = cost,
                ToId = graph[1].Item.ToString(),
                FromId = graph[(uint)graph.NodesCount].Item.ToString()
            };

            return airportResult;
        }

        private static Graph ReadFile(string vehicleType)
        {
            List<string> Froms = new List<string>
            {
                "tanger",
                "tanger",
                "marrakesh",
                "marrakesh",
                "siera leone",
                "guld kysten",
                "guld kysten",
                "launda",
                "st helena",
                "kapstaden",
                "kapstaden",
                "guld kysten",
                "tripoli",
                "darfur",
                "kapstaden",
                "kapstaden",
                "kapstaden",
                "dragjeberget",
                "victoria soen",
                "amatave",
                "darfur",
                "suaken",
                "suaken",
                "kabalo"
            };

            List<string> Tos = new List<string>
            {
                "tripoli",
                "marrakesh",
                "siera leone",
                "guld kysten",
                "st helena",
                "launda",
                "hvalbugten",
                "hvalbugten",
                "kapstaden",
                "kablo",
                "hvalbuguten",
                "tripoli",
                "darfur",
                "kabalo",
                "kap st marie",
                "dragebjerget",
                "amatave",
                "victorian soen",
                "kap guardafui",
                "kap guardafui",
                "suaken",
                "cairo",
                "victorian soen",
                "kapstaden"

            };
            List<SingleConnection> list = new List<SingleConnection>();
            
            for(int i=0; i<22; i++)
            {
                list.Add(new SingleConnection
                {
                    From = Froms[i],
                    To = Tos[i],
                    Weight = 1
                });
            }             

            return new Graph
            {
                Rows = list,
                VehicleType = vehicleType
            };
        }
    }

    public class Graph
    {
        public List<SingleConnection> Rows { get; set; }
        public string VehicleType { get; set; }
    }

    public class SingleConnection
    {
        public string From { get; set; }
        public string To { get; set; }
        public double Weight { get; set; }
    }

    public class ConnectionForCity
    {
        public double Weight { get; set; }
        public string To { get; set; }
        public string VehicleType { get; set; }
    }
}
