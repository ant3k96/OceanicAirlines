using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OceanicAirlines.Domain.EntityModels;

namespace OceanicAirlines.Infrastructue.DbConnection
{
    public class TransportationContext : DbContext
    {
        public TransportationContext() : base("name = TransportationContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TransportationContext, Migrations.Configuration>());
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<RouteCity> RoutesCities { get; set; }
    }
}
