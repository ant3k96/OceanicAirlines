using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanicAirlines.Domain.EntityModels
{
    public class RouteCity
    {
        public Route Route { get; set; }
        [Required]
        public string RouteId { get; set; }
        public City City { get; set; }
        [Required]
        public string CityId { get; set; }
    }
}
