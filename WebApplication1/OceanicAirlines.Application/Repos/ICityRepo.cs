using OceanicAirlines.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanicAirlines.Application.Repos
{
    public interface ICityRepo
    {
        void MarkAsBlacklisted(string cityId);
        IEnumerable<City> GetBlacklisted();
        IEnumerable<City> GetAll();
        IEnumerable<City> GetWithKeyword(string keyword);
        City GetSingle(string cityId);
        City GetSingleByName(string cityName);
        IEnumerable<CityCityConnection> GetConnections();
    }
}
