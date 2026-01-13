using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CinemaDbContext _context;

        public MovieRepository(CinemaDbContext context)
        {
            _context = context;
        }

        public Task<List<Movie>> GetAllAsync()
            => _context.Movies.AsNoTracking().ToListAsync();

        public Task<Movie?> GetByIdAsync(Guid id)
            => _context.Movies.FindAsync(id).AsTask();

        public async Task AddAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
        }
    }

}
