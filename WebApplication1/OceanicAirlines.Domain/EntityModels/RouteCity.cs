using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanicAirlines.Domain.EntityModels
{
    public class RouteCity
    {

        [Required]
        public string Id { get; set; }
        public Route Route { get; set; }
        [Required]
        public Guid? RouteId { get; set; }
        public City City { get; set; }
        [Required]
        public Guid? CityId { get; set; }
    }
}
