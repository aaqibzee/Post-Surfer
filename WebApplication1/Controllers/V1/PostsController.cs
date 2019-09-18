using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Post_Surfer.Domain;
using Post_Surfer.Contract;
using Post_Surfer.Contract.Response;
using System.Linq;
using Post_Surfer.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Post_Surfer.Controllers.V1
{
    [ApiVersion("1.0")]
    //[Route("api/posts")]

    public class PostsController : Controller
    {
        private IPostService _postService;
        public PostsController( PostService postsrvice)
        {
            _postService = postsrvice;
        }

        [HttpGet(APIRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_postService.GetAll());
        }

        [HttpPost(APIRoutes.Posts.Create)]
        public IActionResult Create([FromBody] CreatePostRequest postRequest)
        {
            var post = new Post { Id = postRequest.Id };
            if (post.Id==null)
                post.Id = Guid.NewGuid();
            _postService.AddPost(post);
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            //var locationUrl = baseUrl + "/" + APIRoutes.Posts.Create.Replace("postId", post.Id.ToString);
            var response = new PostsResponse { Id = post.Id };
            return Created(baseUrl, response);
        }

        [HttpGet(APIRoutes.Posts.Get)]
        public IActionResult Get([FromRoute] Guid postId)
        {
            if (postId != Guid.Empty)
            {
                var post = _postService.GetPostById(postId);
                if (post!=null)
                    return Ok(post);
                else
                    return NotFound();
            }
            else
            {
                return BadRequest();
            }
        }
    }   
}
