using Application.Dtos.Customer;

public interface ICustomerService
{
    Task<List<CustomerReadDto>> GetCustomersAsync();
    Task<CustomerReadDto?> GetCustomerAsync(Guid id);
    Task<Guid> CreateCustomerAsync(CustomerCreateDto dto);
}
