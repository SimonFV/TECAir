using System;
using System.Collections.Generic;

#nullable disable

namespace api.Entities
{
    public partial class Rute
    {
        public Rute()
        {
            Flights = new HashSet<Flight>();
        }

        public int Id { get; set; }
        public string Departure { get; set; }
        public string Scale { get; set; }
        public string Arrival { get; set; }

        public string Miles { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
