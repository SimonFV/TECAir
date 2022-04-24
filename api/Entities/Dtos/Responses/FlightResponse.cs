using System;
using System.Collections.Generic;

#nullable disable

namespace api.Entities
{
    public partial class FlightResponse
    {
        public int Id { get; set; }
        public string Departure { get; set; }
        public List<string> Scale { get; set; }
        public string Arrival { get; set; }
        public string Model { get; set; }
        public DateTime Schedule { get; set; }
        public int? Deals { get; set; }
    }
}
