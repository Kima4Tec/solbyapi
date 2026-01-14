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

    [HttpGet]
    public async Task<ActionResult<List<DirectorDto>>> Get()
    {
        var directors = await _service.GetAllDirectorsAsync();
        return Ok(directors);
    }
}
