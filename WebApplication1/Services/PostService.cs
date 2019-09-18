using Post_Surfer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Post_Surfer.Services
{
    public class PostService : IPostService
    {
        private readonly List<Post> _posts;
        public PostService()
        {
            _posts = new List<Post>();
            for (var i = 0; i < 5; i++)
            {
                _posts.Add(new Post { Id = Guid.NewGuid(), Name = $"Post { i}" });
            }
        }
        public  List<Post> GetAll()
        {
            return _posts;

        }
        public  Post GetPostById(Guid Id)
        {
            return _posts.FirstOrDefault(x => x.Id == Id);
        }
        public void AddPost(Post post)
        {
             _posts.Add(post);
        }
    }
}
