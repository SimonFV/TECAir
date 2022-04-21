using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

#nullable enable

namespace api.Entities
{
    public class User : IdentityUser<int>
    {
        public User()
        {
            Baggages = new HashSet<Baggage>();
            Books = new HashSet<Book>();
        }

        public int? Ssn { get; set; }
        public string? FirstName { get; set; }
        public string? LastName1 { get; set; }
        public string? LastName2 { get; set; }
        public string? University { get; set; }
        public int? Schoolid { get; set; }


        public virtual Schoolid? School { get; set; }
        public virtual ICollection<Baggage> Baggages { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}