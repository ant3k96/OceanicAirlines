using OceanicAirlines.Application.Services;
using OceanicAirlines.Domain.EntityModels;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
