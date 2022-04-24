using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Requests
{
    public class FlightDto
    {
        [Required]
        public string Departure { get; set; }
        [Required]
        public string Arrival { get; set; }
        [Required]
        public string PlaneId { get; set; }
        public List<string> Scale { get; set; }
    }
}