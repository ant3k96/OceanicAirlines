using OceanicAirlines.Application.Repos;
using OceanicAirlines.Application.Services;
using OceanicAirlines.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class CityController : ApiController
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }
        public IEnumerable<City> GetBlacklisted()
        {
            return _cityService.GetBlacklisted();
        }

        public IEnumerable<City> GetWithKeyword(string keyword)
        {
            return _cityService.GetWithKeyword(keyword);
        }

        public void MarkAsBlacklisted(string cityId)
        {
            _cityService.MarkAsBlacklisted(cityId);
        }

        public City GetByName(string name)
        {
            return _cityService.GetSingleByName(name);
        }
    }
}
