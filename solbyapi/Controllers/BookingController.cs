using Application.Dtos.Bookings;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/bookings")]
public class BookingsController : ControllerBase
{
    private readonly IBookingService _service;

    public BookingsController(IBookingService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<BookingReadDto>>> Get()
        => Ok(await _service.GetBookingsAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<BookingReadDto>> Get(Guid id)
    {
        var booking = await _service.GetBookingAsync(id);
        return booking is null ? NotFound() : Ok(booking);
    }

    [HttpPost]
    public async Task<IActionResult> Post(BookingCreateDto dto)
    {
        var id = await _service.CreateBookingAsync(dto);
        return CreatedAtAction(nameof(Get), new { id }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, BookingCreateDto dto)
    {
        var updated = await _service.UpdateBookingAsync(id, dto);
        return updated ? NoContent() : NotFound();
    }
}
