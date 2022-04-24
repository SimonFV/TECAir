using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace api.Entities
{
    public partial class BookDto
    {
        [Required]
        public int Ssn { get; set; }
        [Required]
        public int IdFlight { get; set; }
        [Required]
        public string Seat { get; set; }
    }
}
