using Domain.Entities;
using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class DirectorRepository : IDirectorRepository
{
    private readonly AppDbContext _context;

    public DirectorRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<List<Director>> GetAllAsync()
    {
        return _context.Directors.AsNoTracking().ToListAsync();
    }
    public async Task AddAsync(Director director)
    {
        _context.Directors.Add(director);
        await _context.SaveChangesAsync();
    }
}
