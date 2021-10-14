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
        void MarkAsBlacklisted(Guid cityId);
        IEnumerable<City> GetBlacklisted();
        IEnumerable<City> GetAll();
        IEnumerable<City> GetWithKeyword(string keyword);
        City GetSingle(Guid cityId);
    }
}
