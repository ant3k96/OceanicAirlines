using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanicAirlines.Domain.EntityModels
{
    public class RouteCity
    {

        public string Id { get; set; }
        [ForeignKey("RouteId")]
        public Route Route { get; set; }
        public string RouteId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }
        public string CityId { get; set; }
    }
}
