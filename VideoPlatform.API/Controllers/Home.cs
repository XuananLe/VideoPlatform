using Microsoft.AspNetCore.Mvc;

namespace VideoPlatform.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class Home : ControllerBase
{
    [HttpGet]   
    public String Index()
    {
        return "Hello World From Controller!";
    }
}