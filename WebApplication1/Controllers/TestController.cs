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
            string pontosidő = DateTime.Now.ToString();
            return Ok(pontosidő);
        }

        [HttpGet]
        [Route("corvinus/echo/{id}")]
        public IActionResult mind2(string id)
        {
            try
            {
                return Ok(id.ToUpper().Trim());
            }
            catch (Exception)
            {
                return BadRequest("Nem jó a bemenő adat");
            }
        }
    }
}
