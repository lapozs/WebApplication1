using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("corvinus/szerverido")]
        public IActionResult mind1()
        {
            return Ok(DateTime.Now.ToString());
        }

        [HttpGet]
        [Route("corvinus/echo/{id}")]
        public IActionResult mind2(string id)
        {
            return Ok(id.ToUpper().Trim());
        }
    }
}
