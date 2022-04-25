using System;
using System.Collections.Generic;

#nullable disable

namespace api.Entities
{
    // Plane Structure
    public partial class Plane
    {
        public Plane()
        {
            Flights = new HashSet<Flight>();
        }
        // Airplane License
        public string AirplaneLicense { get; set; }
        // Airplane Capacity
        public int Capacity { get; set; }
        // Airplane Model
        public string Model { get; set; }
        // Airplane Status
        public string Status { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
