using Domain.Entities;

namespace Application.Interfaces
{


    public interface IHallRepository
    {
        Task<List<Hall>> GetAllAsync();
        Task<Hall?> GetByIdAsync(Guid id);
        Task AddAsync(Hall hall);
    }
}
