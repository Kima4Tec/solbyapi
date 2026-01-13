using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _service;

        public MoviesController(IMovieService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieReadDto>>> Get()
            => Ok(await _service.GetMoviesAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieReadDto>> Get(Guid id)
        {
            var movie = await _service.GetMovieAsync(id);
            return movie is null ? NotFound() : Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Post(MovieCreateDto dto)
        {
            var id = await _service.CreateMovieAsync(dto);
            return CreatedAtAction(nameof(Get), new { id }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, MovieUpdateDto dto)
        {
            var updated = await _service.UpdateMovieAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }
    }


}
