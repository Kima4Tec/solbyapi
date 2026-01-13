using Application.Dtos.Hall;

namespace Application.Interfaces
{
    public interface IHallService
    {
        Task<List<HallReadDto>> GetHallsAsync();
        Task<HallReadDto?> GetHallAsync(Guid id);
        Task<Guid> CreateHallAsync(HallCreateDto dto);
    }


}
