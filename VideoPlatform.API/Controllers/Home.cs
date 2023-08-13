using Microsoft.AspNetCore.Mvc;

namespace VideoPlatform.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class Home : ControllerBase
{
    [HttpGet]   
    public IActionResult Index()
    {
        var data = new { Message = "Hello World" };
        return new JsonResult(data);
    }
}