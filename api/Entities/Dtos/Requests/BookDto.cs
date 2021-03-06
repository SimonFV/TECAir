using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace api.Entities
{
    public partial class BookDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public int IdFlight { get; set; }
        public string Seat { get; set; }
        public string Status { get; set; }
    }
}
