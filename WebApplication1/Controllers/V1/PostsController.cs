using System;
using Microsoft.AspNetCore.Mvc;
using Post_Surfer.Domain;
using Post_Surfer.Contract;
using Post_Surfer.Contract.Response;
using Post_Surfer.Services;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Post_Surfer.Controllers.V1
{
    //[ApiVersion("1.0")]

    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        public PostsController(IPostService postsrvice)
        {
            _postService = postsrvice;
        }


        [HttpPost(APIRoutes.Posts.Create)]
        public async Task<IActionResult> Create([FromBody] CreatePostRequest postRequest)
        {
            var post = new Post { Name = postRequest.Name,Id= Guid.NewGuid() };
            await _postService.CreatePostAsync(post);
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            //var locationUrl = baseUrl + "/" + APIRoutes.Posts.Create.Replace("postId", post.Id);
            var response = new PostsResponse { Id = post.Id };
            return Created(baseUrl, response);
        }

        [HttpDelete(APIRoutes.Posts.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid postId)
        {
            if (postId == Guid.Empty)
            {
                return BadRequest();
            }

            var status = await _postService.DeletePostAsync(postId);

            if (status)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet(APIRoutes.Posts.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid postId)
        {
            if (postId == Guid.Empty)
            {
                return BadRequest();
            }

            var post =await _postService.GetPostByIdAsync(postId);

            if (post != null)
            {
                return Ok(post);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet(APIRoutes.Posts.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _postService.GetAllAsync());
        }

        [HttpPut(APIRoutes.Posts.Update)]

        public async Task<IActionResult> Update([FromBody] UpdatePostRequest postRequest)
        {
            if (postRequest.Id == Guid.Empty)
            {
                return BadRequest();
            }

            var post = new Post { Id = postRequest.Id, Name = postRequest.Name };
            var status = await _postService.UpdatePostAsync(post);
            if (status)
            {
                return Ok(post);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
