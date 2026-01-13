using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class MovieRepository : IMovieRepository
{
    private readonly AppDbContext _context;

    public MovieRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<List<Movie>> GetAllAsync()
    { 
        return _context.Movies.AsNoTracking().ToListAsync(); 
    }

    public Task<Movie?> GetByIdAsync(Guid id)
    {
        return _context.Movies.AsNoTracking()
                          .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task AddAsync(Movie movie)
    {
        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Movie movie)
    {
        _context.Movies.Update(movie);
        await _context.SaveChangesAsync();
    }
}
