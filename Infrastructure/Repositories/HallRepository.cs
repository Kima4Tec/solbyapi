using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class HallRepository : IHallRepository
{
    private readonly AppDbContext _context;

    public HallRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<List<Hall>> GetAllAsync()
        => _context.Halls.AsNoTracking().ToListAsync();

    public Task<Hall?> GetByIdAsync(Guid id)
        => _context.Halls.AsNoTracking().FirstOrDefaultAsync(h => h.Id == id);

    public async Task AddAsync(Hall hall)
    {
        _context.Halls.Add(hall);
        await _context.SaveChangesAsync();
    }
}
