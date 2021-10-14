using OceanicAirlines.Application.Repos;
using OceanicAirlines.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanicAirlines.Infrastructue.Repos
{
    public class CityRepo : ICityRepo
    {
        public IEnumerable<City> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<City> GetBlacklisted()
        {
            throw new NotImplementedException();
        }

        public City GetSingle(Guid cityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<City> GetWithKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        public void MarkAsBlacklisted(Guid cityId)
        {
            throw new NotImplementedException();
        }
    }
}
