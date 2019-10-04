using Post_Surfer.Contract.V1.Response;
using Post_Surfer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Post_Surfer.Contract.Response
{
    public  class PostsResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
         public IEnumerable<TagResponse> Tags { get; set; }
    }
}
