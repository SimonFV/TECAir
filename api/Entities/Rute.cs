using System;
using System.Collections.Generic;

#nullable disable

namespace api.Entities
{
    // Route Structure
    public partial class Rute
    {
        public Rute()
        {
            Flights = new HashSet<Flight>();
            Scales = new HashSet<Scale>();
        }
        // Unique Route ID
        public int Id { get; set; }
        // Departure Route
        public string Departure { get; set; }
        // Arrival Route
        public string Arrival { get; set; }
        // Milles Route
        public string Miles { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
        // Scale Route
        public virtual ICollection<Scale> Scales { get; set; }
    }
}
