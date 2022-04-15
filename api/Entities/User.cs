using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Entities
{
    public class User : IdentityUser<int>
    {
        public string Ssn { get; set; }
        public string FirstName { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public string University { get; set; }
        public string SchoolId { get; set; }
    }
}