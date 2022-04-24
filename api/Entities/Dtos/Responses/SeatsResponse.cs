using System;
using System.Collections.Generic;

#nullable disable

namespace api.Entities
{
    public partial class SeatsResponse
    {
        public int Ssn { get; set; }
        public string Seat { get; set; }
        public string Status { get; set; }
    }
}
