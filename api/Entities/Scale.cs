using System;
using System.Collections.Generic;

#nullable disable

namespace api.Entities
{
    public partial class Scale
    {
        public int Id { get; set; }
        public int RuteId { get; set; }
        public string Place { get; set; }
        public int OrderLanding { get; set; }

        public virtual Rute Rute { get; set; }
    }
}
