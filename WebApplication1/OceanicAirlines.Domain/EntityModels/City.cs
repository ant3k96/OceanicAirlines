using System;
using System.ComponentModel.DataAnnotations;

namespace OceanicAirlines.Domain.EntityModels
{
    
    public class City
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsBlacklisted { get; set; }
        public string Comment { get; set; }
    }
}
