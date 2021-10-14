using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanicAirlines.Domain.EntityModels
{
    public class Route
    {
        [Required]
        public Guid Id { get; set; }
        public City From { get; set; }
        [Required]
        public Guid FromId { get; set; }
        public City To { get; set; }
        [Required]
        public Guid ToId { get; set; }
        [Required]
        public Size PackageSize { get; set; }
        [Required]
        public Weight PackageWeight { get; set; }
        [Required]
        public Type PackageType { get; set; }
        public IEnumerable<City> GoThroughLocations { get; set; }
    }
}
