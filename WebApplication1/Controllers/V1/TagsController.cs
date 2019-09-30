using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Post_Surfer.Contract;
using Post_Surfer.Services;
using System.Threading.Tasks;

namespace Post_Surfer.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TagsController : Controller
    {
        
        private readonly IPostService _postService;
        public TagsController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpPost(APIRoutes.Tags.GetAll)]
        [Authorize(Policy ="TagViewer")]
        public  async Task<IActionResult> GetAll()
        {

            return Ok(await _postService.GetAllTagsAsync());
        }
    }
}
