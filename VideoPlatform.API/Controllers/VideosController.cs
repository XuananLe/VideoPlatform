using Microsoft.AspNetCore.Mvc;

namespace VideoPlatform.API.Controllers;
[Route("api/videos")]
public class VideosController : ControllerBase
{
    [HttpPost]
    public IActionResult UploadVideo(IFormFile video)
    {
        
        return Ok();
    }
}