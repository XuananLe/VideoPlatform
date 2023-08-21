using Microsoft.AspNetCore.Mvc;

namespace VideoPlatform.API.Controllers;

[Route("api/Videos")]
public class VideosController : ControllerBase
{
    private readonly IWebHostEnvironment _env;

    public VideosController(IWebHostEnvironment env)
    {
        _env = env;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Hello World");
    }


    [HttpPost("Upload")] // POST /api/Videos/Upload
    public IActionResult Create(IFormFile video)
    {
        if (video == null)
        {
            return BadRequest("File is null");
        }
        var mime = video.FileName.Split('.').Last();
        var filename = string.Concat(Path.GetRandomFileName(), ".", mime);
        var savedPath = Path.Combine(_env.WebRootPath, filename);
        using (var fileStream = new FileStream(savedPath, FileMode.Create, FileAccess.Write))
        {
            video.CopyToAsync(fileStream);
        }

        return Ok("File uploaded successfully");
    }
}