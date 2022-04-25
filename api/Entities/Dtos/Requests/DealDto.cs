using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace api.Entities
{
    public partial class DealDto
    {
        [Required]
        public int IdFlight { get; set; }
        [Required]
        public int Deal { get; set; }
    }
}
