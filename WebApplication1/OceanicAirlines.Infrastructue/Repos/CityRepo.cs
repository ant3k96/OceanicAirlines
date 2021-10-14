using OceanicAirlines.Application.Repos;
using OceanicAirlines.Domain.EntityModels;
using OceanicAirlines.Infrastructue.DbConnection;
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
            using (var db = new TransportationContext())
            {
                return db.Cities.Select(x => x).ToList();
            }
        }

        public IEnumerable<City> GetBlacklisted()
        {
            using (var db = new TransportationContext())
            {
                return db.Cities.Select(x => x).Where(x => x.IsBlacklisted==true).ToList();
            }
        }

        public City GetSingle(Guid cityId)
        {
            using (var db = new TransportationContext())
            {
                return db.Cities.FirstOrDefault(x => x.Id == cityId.ToString());
            }
        }

        public IEnumerable<City> GetWithKeyword(string keyword)
        {
            using (var db = new TransportationContext())
            {
                return db.Cities.Select(x => x).Where(x => x.Name.Contains(keyword)).ToList();
            }
        }

        public void MarkAsBlacklisted(Guid cityId)
        {
            using (var db = new TransportationContext())
            {
                var result = db.Cities.SingleOrDefault(x => x.Id == cityId.ToString());
                if (result == null) return;
                result.IsBlacklisted = true;
                db.SaveChanges();
            }
        }
    }
}
