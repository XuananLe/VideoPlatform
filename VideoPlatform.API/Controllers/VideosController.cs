using Microsoft.AspNetCore.Mvc;

namespace VideoPlatform.API.Controllers;
[Route("api/Videos")]
public class VideosController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Hello World");
    }
    
    
    [HttpPost("Upload")] // POST /api/Videos/Upload
    public IActionResult Create([FromBody] object video)
    {
        return Ok("Video uploaded successfully");
        // return Ok("Video uploaded successfully");
        // if (video is { Length: > 0 })
        // {
        //     return Ok("Video uploaded successfully");
        // }

        //return BadRequest("No video file uploaded");
    }
}