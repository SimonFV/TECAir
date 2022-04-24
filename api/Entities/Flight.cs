using System;
using System.Collections.Generic;

#nullable disable

namespace api.Entities
{
    public partial class Flight
    {
        public Flight()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string AirplaneLicense { get; set; }
        public int IdRute { get; set; }
        public string Gate { get; set; }
        public DateTime Schedule { get; set; }
        public string Status { get; set; }
        public int? Deals { get; set; }

        public virtual Plane AirplaneLicenseNavigation { get; set; }
        public virtual Rute IdRuteNavigation { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
