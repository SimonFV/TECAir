using System;
using System.Collections.Generic;

#nullable disable

namespace api.Entities
{
    // Scale Structure
    public partial class Scale
    {
        // Unique Scale ID
        public int Id { get; set; }
        // Assigned Route ID
        public int RuteId { get; set; }
        // Place of the Scale
        public string Place { get; set; }
        // Order of Landing
        public int OrderLanding { get; set; }

        public virtual Rute Rute { get; set; }
    }
}
