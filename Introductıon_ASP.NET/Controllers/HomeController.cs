using Microsoft.AspNetCore.Mvc;
using Introductıon_ASP.NET.Model;

namespace Introductıon_ASP.NET.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : ControllerBase
    {
        //Get method için HttpGET
        [HttpGet]
        public IActionResult GetMessage()
        {
            var result = new ResponseModel()
            {
                HttpStatus = 200,
                ServerMessage = "Sonuç başarılı"
            };
            return Ok(result);
        }

    }
}
