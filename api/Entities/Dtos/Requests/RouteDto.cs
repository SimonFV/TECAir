using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Requests
{
    public class RouteDto
    {
        [Required]
        public string Departure { get; set; }
        [Required]
        public string Arrival { get; set; }
        [Required]
        public List<string> Scale { get; set; }
        [Required]
        public int Miles { get; set; }
    }
}