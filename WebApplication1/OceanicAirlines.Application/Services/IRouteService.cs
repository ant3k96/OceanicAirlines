using OceanicAirlines.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanicAirlines.Application.Services
{
    public interface IRouteService
    {
        void Register(Route route);
        IEnumerable<Route> GetHistory();
        Route FindCheapest();
        Route FindFastest();
    }
}
