using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Post_Surfer.Contract
{
    public class UpdatePostRequest
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
    }
}
