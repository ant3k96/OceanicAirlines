using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanicAirlines.Domain.EntityModels
{
    public class CityCityConnection
    {
        public string Id { get; set; }
        public string FromId { get; set; }
        public string ToId { get; set; }
        //[ForeignKey("FromId")]
        public City CityFrom { get; set; }
        //[ForeignKey("ToId")]
        public City CityTo { get; set; }
    }
}
