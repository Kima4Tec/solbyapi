using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<List<Customer>> GetAllAsync()
        => _context.Customers.AsNoTracking().ToListAsync();

    public Task<Customer?> GetByIdAsync(Guid id)
        => _context.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

    public async Task AddAsync(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
    }


}
