using System;
using System.Collections.Generic;

#nullable disable

namespace api.Entities
{
    // School ID Structure
    public partial class Schoolid
    {
        public Schoolid()
        {
            Users = new HashSet<User>();
        }

        // College ID
        public int Number { get; set; }
        // Accumulate Miles
        public int Mile { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
