using BTKAkademi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BTKAkademi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMessage()
        {
            var result = new ResponseModel()
            {
                HttpStatus = 200,
                Message = "Hello World"
            };
            return Ok(result);
        }
    }
}
