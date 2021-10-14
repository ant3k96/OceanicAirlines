using OceanicAirlines.Application.Repos;
using OceanicAirlines.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web.UI.WebControls.WebParts;
using OceanicAirlines.Infrastructue.DbConnection;

namespace OceanicAirlines.Infrastructue.Repos
{
    public class RouteRepo : IRouteRepo
    {
        public RouteRepo()
        {
        }

        public void Add(Route route)
        {
            using (var db = new TransportationContext())
            {
                db.Routes.Add(route);
                db.SaveChanges();
            }        
        }

        public IEnumerable<Route> GetRouteHistory()
        {
            using (var db = new TransportationContext())
            {
                return db.Routes.Select(x => x).ToList();
            }
        }

        public Route GetSingle(Guid id)
        {
            using (var db = new TransportationContext())
            {
                return db.Routes.SingleOrDefault(x => x.Id == id.ToString());
            }
        }
    }
}
