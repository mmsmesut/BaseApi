using Microsoft.AspNetCore.Mvc;

namespace BaseApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //Calling : "api/Home" -> [Route("api/[controller]")]
    //Calling : "Home" -> [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        [HttpGet]//https://localhost:7018/api/Home
        public ActionResult<string> Get()
        {
            return "Hello World from Web API!ss";
        }

        [HttpGet]
        [Route("Gets")]//https://localhost:7018/api/Home/gets
        public ActionResult<string> Gets()
        {
            return "Hello World from Web API!ss";
        }
    }
}
