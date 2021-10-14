using OceanicAirlines.Domain.EntityModels;
using OceanicAirlines.Infrastructue.DbConnection;

namespace OceanicAirlines.Infrastructue.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OceanicAirlines.Infrastructue.DbConnection.TransportationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OceanicAirlines.Infrastructue.DbConnection.TransportationContext context)
        {
            
            
        }
    }
}
