using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using VideoPlatform.API.Service;

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
        // LINQ
        var files = Directory.GetFiles("wwwroot/").Select(file => file.Replace("wwwroot/", "")).ToArray();
        return Ok(files);
    }
    


    [HttpGet("{video}")]
    public IActionResult Get(string video)
    {
        if (video == null)
        {
            return BadRequest("File is null");
        }

        var filePath = Path.Combine(_env.WebRootPath, video);
        if (!System.IO.File.Exists(filePath))
        {
            return NotFound(video + " not found");
        }

        return new FileStreamResult(System.IO.File.OpenRead(filePath), "image/png");
    }

    [HttpPost("Upload")] // POST /api/Videos/Upload
    public async Task<IActionResult> Create(IFormFile video)
    {
        if (video == null)
        {
            return BadRequest("File is null");
        }

        var mime = video.FileName.Split('.').Last();

        var filename = GuidService.generateShortGUID() + "." + mime;
        var savedPath = Path.Combine(_env.WebRootPath, filename);
        
        using (var fileStream = new FileStream(savedPath, FileMode.Create, FileAccess.Write))
        {
            await video.CopyToAsync(fileStream);
        }

        return Ok("File uploaded successfully");
    }
}