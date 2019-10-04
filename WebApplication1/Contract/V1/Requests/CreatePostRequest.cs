using System;
using System.Collections.Generic;

namespace Post_Surfer.Contract
{
    public class CreatePostRequest
    {
        public String Name { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}
