using Application.Dtos.Shows;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/shows")]
public class ShowsController : ControllerBase
{
    private readonly IShowService _service;

    public ShowsController(IShowService service)
    {
        _service = service;
    }

    // GET: api/shows
    [HttpGet]
    public async Task<ActionResult<List<ShowReadDto>>> Get()
        => Ok(await _service.GetShowsAsync());

    // GET: api/shows/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<ShowReadDto>> Get(Guid id)
    {
        var show = await _service.GetShowAsync(id);
        return show is null ? NotFound() : Ok(show);
    }

    // GET api/shows/movie/{movieId}
    [HttpGet("movie/{movieId}")]
    public async Task<ActionResult<List<ShowReadDto>>> GetByMovie(Guid movieId)
    {
        return Ok(await _service.GetShowsByMovieAsync(movieId));
    }

    // POST: api/shows
    [HttpPost]
    public async Task<IActionResult> Post(ShowCreateDto dto)
    {
        var id = await _service.CreateShowAsync(dto);
        return CreatedAtAction(nameof(Get), new { id }, null);
    }
}
