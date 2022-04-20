using System;
using System.Collections.Generic;

#nullable disable

namespace api.Entities
{
    public partial class Plane
    {
        public Plane()
        {
            Flights = new HashSet<Flight>();
        }

        public string AirplaneLicense { get; set; }
        public int Capacity { get; set; }
        public string Model { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
