using System;
using System.Collections.Generic;

#nullable disable

namespace api.Entities
{
    // Flight structure
    public partial class Flight
    {
        public Flight()
        {
            Books = new HashSet<Book>();
        }
        // Unique Flight ID
        public int Id { get; set; }
        // Assigned Airplane License
        public string AirplaneLicense { get; set; }
        // ID of the Assigned Rute
        public int IdRute { get; set; }
        // Boarding Gate
        public string Gate { get; set; }
        // Departure time
        public DateTime Schedule { get; set; }
        // Flight Status
        public string Status { get; set; }
        // Flight Deal
        public int? Deals { get; set; }

        public virtual Plane AirplaneLicenseNavigation { get; set; }
        public virtual Rute IdRuteNavigation { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
