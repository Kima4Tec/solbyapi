using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(Guid id);
        Task AddAsync(Movie movie);
        Task<List<Director>> GetDirectorsByIdsAsync(List<Guid> ids);
        Task UpdateAsync(Movie movie);
    }

}
