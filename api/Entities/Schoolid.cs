using System;
using System.Collections.Generic;

#nullable disable

namespace api.Entities
{
    public partial class Schoolid
    {
        public Schoolid()
        {
            Users = new HashSet<User>();
        }

        public int Number { get; set; }
        public int Mile { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
