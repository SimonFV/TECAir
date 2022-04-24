using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace api.Entities
{
    public partial class BaggageDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public string Color { get; set; }
    }
}
