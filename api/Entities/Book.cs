using System;
using System.Collections.Generic;

#nullable disable

namespace api.Entities
{
    public partial class Book
    {
        public int Ssn { get; set; }
        public int IdFlight { get; set; }
        public string Seat { get; set; }

        public string Status { get; set; }

        public virtual Flight IdFlightNavigation { get; set; }
        public virtual User SsnNavigation { get; set; }
    }
}
