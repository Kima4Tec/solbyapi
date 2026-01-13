using Application.Dtos.Hall;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/halls")]
public class HallsController : ControllerBase
{
    private readonly IHallService _service;

    public HallsController(IHallService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<HallReadDto>>> Get()
        => Ok(await _service.GetHallsAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<HallReadDto>> Get(Guid id)
    {
        var hall = await _service.GetHallAsync(id);
        return hall is null ? NotFound() : Ok(hall);
    }

    [HttpPost]
    public async Task<IActionResult> Post(HallCreateDto dto)
    {
        var id = await _service.CreateHallAsync(dto);
        return CreatedAtAction(nameof(Get), new { id }, null);
    }

}
