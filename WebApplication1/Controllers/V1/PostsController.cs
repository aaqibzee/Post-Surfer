using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Domain;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers.V1
{
    [ApiVersion("1.0")]
    public class PostsController : Controller
    {
        private List<Post> _posts;
        // GET: /<controller>/
        public PostsController()
        {
            _posts = new List<Post>();
            for(var i=0;i<5;i++)
            {
                _posts.Add(new Post { Id = Guid.NewGuid().ToString() });
            }
        }
        [HttpGet("api/posts")]
        public IActionResult GetAll()
        {
            return Ok(_posts);
        }
    }
}
