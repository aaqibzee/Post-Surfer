
using System.Collections.Generic;

namespace Post_Surfer.Contract.V1.Response
{
    public class AuthFailedResponse
    {
            public IEnumerable<string> Errors { get; set; }
    }
}
