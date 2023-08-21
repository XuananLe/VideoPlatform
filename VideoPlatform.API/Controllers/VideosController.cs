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

        if (!video.Contains(".mp4"))
        {
            video += ".mp4";
        }
        var filePath = Path.Combine(_env.WebRootPath, video);
        if (!System.IO.File.Exists(filePath))
        {
            return NotFound(video + " not found");
        }

        return new FileStreamResult(System.IO.File.OpenRead(filePath), "video/mp4");
    }

    [HttpPost("Upload")] // POST /api/Videos/Upload
    public async Task<IActionResult> Create(IFormFile video)
    {
        if (video == null || video.Length == 0)
        {
            return Ok("Invalid file.");
        }

        var fileExtension = Path.GetExtension(video.FileName).ToLower();
    
        if (fileExtension != ".mp4")
        {
            return Ok("File format is not supported. Please upload an mp4 video.");
        }

        var filename = $"{GuidService.generateShortGUID()}{fileExtension}";
        var savedPath = Path.Combine(_env.WebRootPath, filename);

        await using var fileStream = new FileStream(savedPath, FileMode.Create, FileAccess.Write);
        await video.CopyToAsync(fileStream);

        return Ok("File uploaded successfully.");
    }

    [HttpPost("UploadMultiple")] // POST /api/Videos/UploadMultiple
    public async Task<IActionResult> CreateMultiple(IFormFileCollection fileCollection)
    {
        if (fileCollection.Count <= 0 || fileCollection == null)
        {
            return Ok("Please select at least one file.");
        }
        foreach(var video in fileCollection)
        {
            var fileExtension = Path.GetExtension(video.FileName).ToLower();
    
            if (fileExtension != ".mp4")
            {
                return Ok($"The file {video.FileName} is not an mp4 video.");
            }
            var filename = $"{GuidService.generateShortGUID()}{fileExtension}";
            var savedPath = Path.Combine(_env.WebRootPath, filename);

            await using var fileStream = new FileStream(savedPath, FileMode.Create, FileAccess.Write);
            await video.CopyToAsync(fileStream); 
        }

        return Ok("All file uploaded successfully.");
    }

}