using Application.Dtos.Shows;

public interface IShowService
{
    Task<List<ShowReadDto>> GetShowsAsync();
    Task<ShowReadDto?> GetShowAsync(Guid id);
    Task<Guid> CreateShowAsync(ShowCreateDto dto);
    Task<List<ShowReadDto>> GetShowsByMovieAsync(Guid movieId);
}
