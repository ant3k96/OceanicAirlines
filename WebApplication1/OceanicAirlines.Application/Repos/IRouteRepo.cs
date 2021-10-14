using OceanicAirlines.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanicAirlines.Application.Repos
{
    public interface IRouteRepo
    {
        void Add(Route route);
        IEnumerable<Route> GetRouteHistory();
        Route GetSingle(Guid id);
    }
}
