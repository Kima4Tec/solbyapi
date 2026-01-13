using Application.Dtos.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMovieService
    {
        Task<List<MovieReadDto>> GetMoviesAsync();
        Task<MovieReadDto?> GetMovieAsync(Guid id);
        Task<Guid> CreateMovieAsync(MovieCreateDto dto);
        Task<bool> UpdateMovieAsync(Guid id, MovieUpdateDto dto);
    }


}
