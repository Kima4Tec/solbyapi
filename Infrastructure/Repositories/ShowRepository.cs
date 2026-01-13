using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class ShowRepository : IShowRepository
{
    private readonly AppDbContext _context;

    public ShowRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<List<Show>> GetAllAsync()
    {
        return _context.Shows
            .Include(s => s.Movie) 
            .Include(s => s.Hall) 
            .AsNoTracking()
            .ToListAsync();
    }

    public Task<Show?> GetByIdAsync(Guid id)
    {
        return _context.Shows
            .Include(s => s.Movie)
            .Include(s => s.Hall)
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public Task<List<Show>> GetByMovieIdAsync(Guid movieId)
    {
        return _context.Shows
            .Include(s => s.Movie)
            .Include(s => s.Hall)
            .AsNoTracking()
            .Where(s => s.MovieId == movieId)
            .ToListAsync();
    }


    public async Task AddAsync(Show show)
    {
        _context.Shows.Add(show);
        await _context.SaveChangesAsync();
    }
}
