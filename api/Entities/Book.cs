using System;
using System.Collections.Generic;

#nullable disable

namespace api.Entities
{
    //Book structure
    public partial class Book
    {
        // Unique ID of the Book
        public int Id { get; set; }
        // ID of the customer
        public int IdUser { get; set; }
        // ID of the Flight
        public int IdFlight { get; set; }
        // Assigned Seat
        public string Seat { get; set; }
        // Book status
        public string Status { get; set; }

        public virtual Flight IdFlightNavigation { get; set; }
        public virtual User UserNavigation { get; set; }
    }
}
