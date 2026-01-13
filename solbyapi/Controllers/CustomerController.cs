using Application.Dtos.Customer;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/customers")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _service;

    public CustomersController(ICustomerService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<CustomerReadDto>>> Get()
        => Ok(await _service.GetCustomersAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerReadDto>> Get(Guid id)
    {
        var customer = await _service.GetCustomerAsync(id);
        return customer is null ? NotFound() : Ok(customer);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CustomerCreateDto dto)
    {
        var id = await _service.CreateCustomerAsync(dto);
        return CreatedAtAction(nameof(Get), new { id }, null);
    }


}
