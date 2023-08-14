using Microsoft.AspNetCore.Mvc;

namespace VideoPlatform.API.Controllers;
[Route("api/videos")]
public class VideosController : ControllerBase
{
    [HttpPost] // POST /api/videos
    public IActionResult UploadVideo(IFormFile video)
    {
        
        return Ok();
    }
}