using Domain.Entities;

namespace Application.Interfaces
{

    public interface IShowRepository
    {
        Task<List<Show>> GetAllAsync();
        Task<Show?> GetByIdAsync(Guid id);
        Task AddAsync(Show show);
        Task<List<Show>> GetByMovieIdAsync(Guid movieId);
    }


}
