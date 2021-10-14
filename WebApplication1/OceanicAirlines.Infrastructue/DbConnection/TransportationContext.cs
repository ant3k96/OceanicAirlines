using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
        public DbSet<CityCityConnection> CityCityConnections { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<City>().
            //    HasMany(x => x.RouteCities).
            //    WithRequired(x=> x.City).
            //    HasForeignKey(x=> x.CityId).WillCascadeOnDelete();

            //modelBuilder.Entity<Route>().
            //    HasMany(x => x.RouteCities).
            //    WithRequired(x => x.Route).
            //    HasForeignKey(x => x.RouteId).WillCascadeOnDelete();

            //modelBuilder.Entity<City>().HasMany(x => x.FromCities).WithRequired(x => x.CityFrom)
            //    .HasForeignKey(x => x.NameFrom);


            //modelBuilder.Entity<City>().
            //    HasMany(x => x.ToCities).
            //    WithRequired(x => x.CityTo).
            //    HasForeignKey(x => x.NameTo).WillCascadeOnDelete();
            modelBuilder.Entity<CityCityConnection>().
                HasRequired(x => x.CityFrom).
                WithMany(x => x.FromCities).HasForeignKey(x => x.FromId)
                .WillCascadeOnDelete();
            modelBuilder.Entity<CityCityConnection>().
                HasRequired(x => x.CityTo).
                WithMany(x => x.ToCities).HasForeignKey(x => x.ToId)
                .WillCascadeOnDelete();


        }
    }
}
