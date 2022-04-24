using System;
using System.Collections.Generic;

#nullable disable

namespace api.Entities
{
    public partial class Baggage
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public string Status { get; set; }

        public virtual User UserNavigation { get; set; }
    }
}
