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
        private string _fromId;
        private string _toId;
        public string FromId 
        { 
            get
            {
                return _fromId;
            }
            set
            {
                _fromId = value.ToLower();
            }
        }
        public string ToId 
        {
            get
            {
                return _toId;
            }
            set
            {
                _toId = value.ToLower();
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
