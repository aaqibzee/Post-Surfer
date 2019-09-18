using Post_Surfer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Post_Surfer.Services
{
   public interface IPostService
    {
        List<Post> GetAll();
        Post GetPostById(Guid Id);
        void AddPost(Post post);
        bool UpdatePost(Post post);
    }
}
