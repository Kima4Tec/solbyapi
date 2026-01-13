using Application.Dtos.Customer;
using Application.Interfaces;
using Domain.Entities;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CustomerReadDto>> GetCustomersAsync()
    {
        var customers = await _repository.GetAllAsync();
        return customers.Select(c => new CustomerReadDto
        {
            Id = c.Id,
            Name = c.Name
        }).ToList();
    }

    public async Task<CustomerReadDto?> GetCustomerAsync(Guid id)
    {
        var customer = await _repository.GetByIdAsync(id);
        if (customer is null) return null;

        return new CustomerReadDto
        {
            Id = customer.Id,
            Name = customer.Name
        };
    }

    public async Task<Guid> CreateCustomerAsync(CustomerCreateDto dto)
    {
        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            Name = dto.Name
        };
        await _repository.AddAsync(customer);
        return customer.Id;
    }


}
