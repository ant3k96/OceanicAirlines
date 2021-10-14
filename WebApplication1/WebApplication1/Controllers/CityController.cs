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
