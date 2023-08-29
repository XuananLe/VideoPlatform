using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoPlatform.Data;
using VideoPlatform.Models;

namespace VideoPlatform.API.Controllers;

[ApiController]
[Route("api/Tricks")]
public class TricksController : ControllerBase
{

    private readonly AppDbContext AppDbContext;
    public TricksController(AppDbContext AppDbContext)
    {
        this.AppDbContext = AppDbContext;
    }

    [HttpGet] // GET /api/Tricks
    public IActionResult GetAll()
    {
        return Ok(AppDbContext.Tricks.ToList());
    }

    [HttpGet("{id}")] // GET /api/Tricks/1
    public IActionResult Get(int id)
    {
        return Ok(AppDbContext.Tricks.FirstOrDefault(x => x.Id.Equals(id)));
    }

    [HttpPost] // POST /api/Tricks
    public async  Task<IActionResult> Create([FromBody] Trick trick)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        if (AppDbContext.Tricks.FirstOrDefault(x => x.Name == trick.Name) == null)
        {
            AppDbContext.Tricks.Add(trick);
            await AppDbContext.SaveChangesAsync();
            return Ok("Trick created.");
        }

        return Ok("Trick already exists.");
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Trick trick)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var trickToUpdate = AppDbContext.Tricks.FirstOrDefault(x => x.Id.Equals(trick.Id));
        if (trickToUpdate == null)
        {
            return NotFound();
        }
        trickToUpdate.Name = trick.Name;
        await AppDbContext.SaveChangesAsync();
        return Ok();
    }


    [HttpDelete("{id}")] // DELETE /api/Tricks/1
    public async Task<IActionResult> Delete(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var trick = AppDbContext.Tricks.FirstOrDefault(x => x.Id.Equals(id));
        if (trick == null)
        {
            return NotFound($"Trick with {id} not found.");
        }
        AppDbContext.Tricks.Remove(trick);
        await AppDbContext.SaveChangesAsync();
        return Ok();
    }
    
}