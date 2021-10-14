using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanicAirlines.Domain.DTOs
{
    public class FindRouteRequest
    {
        private string _type;
        public string FromId { get; set; }
        public string ToId { get; set; }
        public IEnumerable<double> Size { get; set; }
        public double Weight { get; set; }
        public string Type 
        { 
            get
            {
                return _type;
            }
            set
            {
                _type = value.ToLower();
            }
        }
    }
}
