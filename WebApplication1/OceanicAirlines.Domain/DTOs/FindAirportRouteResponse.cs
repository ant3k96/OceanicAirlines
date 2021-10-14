using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanicAirlines.Domain.DTOs
{
    public class FindAirportRouteResponse
    {
        public string FromName { get; set; }
        public string ToName { get; set; }
        public string FromId { get; set; }
        public string ToId { get; set; }
        public double Cost { get; set; }
        public double Duration { get; set; }
        public string Type { get; set; }
        public double Weight { get; set; }
    }
}
