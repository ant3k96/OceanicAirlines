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
        public string Id { get; set; }
        public City From { get; set; }
        [Required]
        public string FromId { get; set; }
        public City To { get; set; }
        [Required]
        public string ToId { get; set; }
        [Required]
        public Size PackageSize { get; set; }
        [Required]
        public Weight PackageWeight { get; set; }
        [Required]
        public Type PackageType { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public double Duration { get; set; }
        public IEnumerable<City> GoThroughLocations { get; set; }
    }
}
