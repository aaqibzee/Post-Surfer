using System;
using Microsoft.AspNetCore.Mvc;
using Post_Surfer.Domain;
using Post_Surfer.Contract;
using Post_Surfer.Contract.Response;
using Post_Surfer.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Post_Surfer.Extensions;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Post_Surfer.Controllers.V1
{
    //[ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostsController(IPostService postService,
            IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }


        [HttpPost(APIRoutes.Posts.Create)]
        public async Task<IActionResult> Create([FromBody] CreatePostRequest postRequest)
        {
            var newPostId = Guid.NewGuid();
            var post = new Post
            {
                Name = postRequest.Name,
                Id = newPostId,
                UserId = HttpContext.GetUserId(),
                Tags = postRequest.Tags.Select(x => new PostTag
                    {
                        PostId = newPostId,
                        TagName = x
                    })
                    .ToList()
            };
            await _postService.CreatePostAsync(post);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl +
                              "/" +
                              APIRoutes.Posts.Get.Replace("{postId}",
                                  post.Id.ToString());
            return Created(baseUrl,
                _mapper.Map<PostsResponse>(post));
        }

        [HttpDelete(APIRoutes.Posts.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid postId)
        {
            if (postId == Guid.Empty)
            {
                return BadRequest();
            }

            var userOwnsPost = await _postService.UserOwnsPostAsync(postId,
                HttpContext.GetUserId());
            if (!userOwnsPost)
            {
                return BadRequest(new
                {
                    error = "You do not own the post"
                });
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

            var post = await _postService.GetPostByIdAsync(postId);

            if (post != null)
            {
                return Ok(_mapper.Map<PostsResponse>(post));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet(APIRoutes.Posts.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var post = await _postService.GetAllAsync();
            return Ok(_mapper.Map<List<PostsResponse>>(post));
        }

        [HttpPut(APIRoutes.Posts.Update)]
        public async Task<IActionResult> Update([FromBody] UpdatePostRequest postRequest)
        {
            if (postRequest.Id == Guid.Empty)
            {
                return BadRequest();
            }

            var userOwnsPost = await _postService.UserOwnsPostAsync(postRequest.Id,
                HttpContext.GetUserId());
            if (!userOwnsPost)
            {
                return BadRequest(new
                {
                    error = "You do not own the post"
                });
            }

            var post = await _postService.GetPostByIdAsync(postRequest.Id);
            post.Name = postRequest.Name;
            var status = await _postService.UpdatePostAsync(post);
            if (status)
            {
                return Ok(_mapper.Map<PostsResponse>(post));
            }
            else
            {
                return NotFound();
            }
        }
    }
}