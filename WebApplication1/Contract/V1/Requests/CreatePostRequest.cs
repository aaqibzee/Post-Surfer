using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Post_Surfer.Contract
{
    public class CreatePostRequest
    {
        public String Name { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}
