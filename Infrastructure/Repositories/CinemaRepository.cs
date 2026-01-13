using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class CinemaRepository : ICinemaRepository
{
    private readonly AppDbContext _context;

    public CinemaRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<List<Cinema>> GetAllAsync()
        => _context.Cinemas.AsNoTracking().ToListAsync();

    public Task<Cinema?> GetByIdAsync(Guid id)
        => _context.Cinemas.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

    public async Task AddAsync(Cinema cinema)
    {
        _context.Cinemas.Add(cinema);
        await _context.SaveChangesAsync();
    }

}

