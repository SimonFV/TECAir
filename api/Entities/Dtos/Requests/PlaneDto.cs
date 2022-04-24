using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Requests
{
    public class PlaneDto
    {
        [Required]
        public string AirplaneLicense { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public string Model { get; set; }
    }
}