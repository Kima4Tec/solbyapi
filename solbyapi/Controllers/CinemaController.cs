using Application.Dtos.Cinemas;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/cinemas")]
public class CinemasController : ControllerBase
{
    private readonly ICinemaService _service;

    public CinemasController(ICinemaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<CinemaReadDto>>> Get()
        => Ok(await _service.GetCinemasAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<CinemaReadDto>> Get(Guid id)
    {
        var cinema = await _service.GetCinemaAsync(id);
        return cinema is null ? NotFound() : Ok(cinema);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CinemaCreateDto dto)
    {
        var id = await _service.CreateCinemaAsync(dto);
        return CreatedAtAction(nameof(Get), new { id }, null);
    }

}
