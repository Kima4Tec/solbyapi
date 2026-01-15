using Application.Dtos.Director;

namespace Application.Interfaces
{
    public interface IDirectorService
    {
        Task<List<DirectorDto>> GetAllDirectorsAsync();
        Task<Guid> CreateDirectorAsync(DirectorCreateDto dto);
    }
}
