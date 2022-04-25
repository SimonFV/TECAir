using System;
using System.Collections.Generic;

#nullable disable

namespace api.Entities
{
    //Baggage structure
    public partial class Baggage
    {
        // Unique ID for the Baggage
        public int Id { get; set; }
        // ID of the Owner
        public int IdUser { get; set; }
        // Baggage Weight
        public int Weight { get; set; }
        // Baggage Color
        public string Color { get; set; }
        // Baggage Status
        public string Status { get; set; }

        public virtual User UserNavigation { get; set; }
    }
}
