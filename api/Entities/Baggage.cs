using System;
using System.Collections.Generic;

#nullable disable

namespace api.Entities
{
    public partial class Baggage
    {
        public int Uniqueid { get; set; }
        public int Ssn { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public string Status { get; set; }

        public virtual User SsnNavigation { get; set; }
    }
}
