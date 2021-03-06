using System.Collections.Generic;

namespace api.Configuration
{
    public class AuthResult
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public string Role { get; set; }
        public List<string> Errors { get; set; }
    }
}