using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class BoatController : ControllerBase
    {
        [HttpGet]
        [Route("hajo/kerdesek")]
        public IActionResult fuggvenynev()
        {
            Models.HajosContext hajosContext = new Models.HajosContext();
            var lista = from x in hajosContext.Questions select x;
            return Ok(lista);
        }

        [HttpGet]
        [Route("hajo/kerdesek/{id}")]
        public IActionResult f2(int id)
        {
            Models.HajosContext hajosContext = new Models.HajosContext();
            var lisa = from x in hajosContext.Questions
                       where x.QuestionId == id
                       select x;

            //ugyanaz ^^ˇˇ

            var lisa2 = hajosContext.Questions.Where(x => x.QuestionId == id);
            return Ok(lisa.FirstOrDefault());
        }
    }
}
