using Application.Dtos.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    using Application.Dtos.Cinemas;

    public interface ICinemaService
    {
        Task<List<CinemaReadDto>> GetCinemasAsync();
        Task<CinemaReadDto?> GetCinemaAsync(Guid id);
        Task<Guid> CreateCinemaAsync(CinemaCreateDto dto);
    }



}
