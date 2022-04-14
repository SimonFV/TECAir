using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Requests
{
    public class UserRegistrationDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string LastName1 { get; set; }
        [Required]
        public string LastName2 { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string University { get; set; }
        [Required]
        public string Ssn { get; set; }
    }
}