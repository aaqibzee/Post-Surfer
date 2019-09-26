using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Post_Surfer.Domain
{
    public class AuthenticationResult
    {
        public IEnumerable <string>Errors { get; set; }
        public string RefreshToken { get; set; }
        public bool Success { get; set; }
        public string Token { get; set; }
    }
}
