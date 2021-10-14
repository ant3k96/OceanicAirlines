using OceanicAirlines.Application.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanicAirlines.Infrastructue.Repos
{
    public class RouteRepo : IRouteRepo
    {
        public string GetRoute()
        {
            return "route";
        }
    }
}
