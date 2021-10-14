using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanicAirlines.Domain.EntityModels
{
    public class Route
    {
        public string Id { get; set; }
        public string FromId { get; set; }
        public string ToId { get; set; }
        public Size PackageSize { get; set; }
        public Weight PackageWeight { get; set; }
        public Type PackageType { get; set; }
        public DateTime Date { get; set; }
        public double Duration { get; set; }
        public ICollection<RouteCity> RouteCities { get; set; }
    }
}

