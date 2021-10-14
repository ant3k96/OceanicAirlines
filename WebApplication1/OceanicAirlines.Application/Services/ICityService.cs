using OceanicAirlines.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanicAirlines.Application.Services
{
    public interface ICityService
    {
        void MarkAsBlacklisted(City city);
        IEnumerable<City> GetBlacklisted();
        IEnumerable<City> GetWithKeyword(string keyword);
    }
}
