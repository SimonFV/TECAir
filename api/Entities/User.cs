using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

#nullable enable

namespace api.Entities
{
    // User Structue
    public class User : IdentityUser<int>
    {
        public User()
        {
            Baggages = new HashSet<Baggage>();
            Books = new HashSet<Book>();
        }
        // SSN
        public int? Ssn { get; set; }
        // First Name of the User
        public string? FirstName { get; set; }
        // First Last Name of the User
        public string? LastName1 { get; set; }
        // Second Last Name of the User
        public string? LastName2 { get; set; }
        // University of the User
        public string? University { get; set; }
        // User School ID
        public int? Schoolid { get; set; }


        public virtual Schoolid? School { get; set; }
        public virtual ICollection<Baggage> Baggages { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}