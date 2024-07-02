using BaseApi.Core;
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
        public ActionResult<Response<string>> Get()
        {
            var response = new Response<string>("Hello world from web api!", 200);
            return Ok(response);
        }

        [HttpGet]
        [Route("Gets")]//https://localhost:7018/api/Home/gets
        public ActionResult<string> Gets()
        {
            return "Hello World from Web API!ss";
        }
    }
}
