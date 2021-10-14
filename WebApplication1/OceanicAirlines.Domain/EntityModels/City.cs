using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OceanicAirlines.Domain.EntityModels
{
    
    public class City
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsBlacklisted { get; set; }
        public string Comment { get; set; }
        public ICollection<RouteCity> RouteCities { get; set; }
        public  ICollection<CityCityConnection> FromCities { get; set; }
        public ICollection<CityCityConnection> ToCities { get; set; }

    }
}
