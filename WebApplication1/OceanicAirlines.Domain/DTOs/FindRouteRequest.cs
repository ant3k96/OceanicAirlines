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
        private string _fromName;
        private string _toName;
        public string FromName 
        { 
            get
            {
                return _fromName;
            }
            set
            {
                _fromName = value.ToLower();
            }
        }
        public string ToName 
        {
            get
            {
                return _toName;
            }
            set
            {
                _toName = value.ToLower();
            }
        }
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
