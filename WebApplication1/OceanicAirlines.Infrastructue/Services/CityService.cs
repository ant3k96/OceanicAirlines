using OceanicAirlines.Application.Repos;
using OceanicAirlines.Application.Services;
using OceanicAirlines.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanicAirlines.Infrastructue.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepo _cityRepo;

        public CityService(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }
        public IEnumerable<City> GetBlacklisted()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<City> GetWithKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        public void MarkAsBlacklisted(City city)
        {
            throw new NotImplementedException();
        }
    }
}
