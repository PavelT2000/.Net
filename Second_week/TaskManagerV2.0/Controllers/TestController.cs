using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagerV2._0.Controllers
{
    [Route("Test")]
    public class TestController : Controller
    {
        
        [HttpGet("Hello")]
        [Authorize]
        public ActionResult Hello()
        {
            return Ok("Hello");
        }
      
        
    }
}
