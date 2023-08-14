using Microsoft.AspNetCore.Mvc;
using VideoPlatform.API.Models;

namespace VideoPlatform.API.Controllers;

[ApiController]
[Route("api/Tricks")]
public class TricksController : ControllerBase
{
    private readonly TrickyStore _trickyStore;

    public TricksController(TrickyStore trickyStore)
    {
        _trickyStore = trickyStore;
    }

    [HttpGet] // GET /api/Tricks
    public IActionResult All()
    {
        return Ok(_trickyStore.All);
    }

    [HttpGet("{id}")] // GET /api/Tricks/1
    public IActionResult Get(int id)
    {
        return Ok(_trickyStore.All.FirstOrDefault(x => x.Id.Equals(id)));
    }

    [HttpPost] // POST /api/Tricks
    public IActionResult Create([FromBody] Trick trick)
    {
        _trickyStore.AddTrick(trick);
        return Ok();
    }

    [HttpPut]
    public IActionResult Update([FromBody] Trick trick)
    {
        var trickToUpdate = _trickyStore.All.FirstOrDefault(x => x.Id.Equals(trick.Id));
        if (trickToUpdate == null)
        {
            return NotFound();
        }
        trickToUpdate.Name = trick.Name;
        return Ok();
    }


    [HttpDelete("{id}")] // DELETE /api/Tricks/1
    public IActionResult Delete(int id)
    {
        var trick = _trickyStore.All.FirstOrDefault(x => x.Id.Equals(id));
        if (trick == null)
        {
            return NotFound();
        }
        _trickyStore.All.ToList().Remove(trick);
        return Ok();
    }
    
}