using Microsoft.AspNetCore.Mvc;

namespace Post_Surfer.Controllers
{
    [ApiVersion("1.1")]
    public class TestController: Controller
    {
        [HttpGet("api/user")]
        public IActionResult Get()
        {
            return Ok(new { name = "Lambda" });
        }
    }
}
