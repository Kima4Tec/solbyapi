using Application.Dtos.Director;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/directors")]
public class DirectorsController : ControllerBase
{
    private readonly IDirectorService _service;

    public DirectorsController(IDirectorService service)
    {
        _service = service;
    }

    // GET: api/directors
    [HttpGet]
    public async Task<ActionResult<List<DirectorDto>>> Get()
    {
        var directors = await _service.GetAllDirectorsAsync();
        return Ok(directors);
    }

    // POST: api/directors
    [HttpPost]
    public async Task<IActionResult> Post(DirectorCreateDto dto)
    {
        var id = await _service.CreateDirectorAsync(dto);
        return CreatedAtAction(nameof(Get), new { id }, null);
    }
}
