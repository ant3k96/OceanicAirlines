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
            return _cityRepo.GetBlacklisted();
        }

        public City GetSingleByName(string name)
        {
            return _cityRepo.GetSingleByName(name);
        }

        public IEnumerable<City> GetWithKeyword(string keyword)
        {
            return _cityRepo.GetWithKeyword(keyword);
        }

        public void MarkAsBlacklisted(string cityId)
        {
            _cityRepo.MarkAsBlacklisted(cityId);
        }
    }
}
