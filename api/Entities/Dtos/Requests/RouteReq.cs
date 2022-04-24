using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Requests
{
    public class RouteReq
    {
        [Required]
        public string Departure { get; set; }
        [Required]
        public string Arrival { get; set; }
    }
}