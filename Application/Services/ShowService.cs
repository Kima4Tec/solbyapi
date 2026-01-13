using Application.Dtos.Shows;
using Application.Interfaces;
using Domain.Entities;

public class ShowService : IShowService
{
    private readonly IShowRepository _repository;

    public ShowService(IShowRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ShowReadDto>> GetShowsAsync()
    {
        var shows = await _repository.GetAllAsync(); 
        return shows.Select(s => new ShowReadDto
        {
            Id = s.Id,
            HallId = s.HallId,
            MovieId = s.MovieId,
            StartTime = s.StartTime,
            Price = s.Price,
            MovieTitle = s.Movie?.Title ?? "", 
            HallName = s.Hall?.Name ?? ""     
        }).ToList();
    }

    public async Task<ShowReadDto?> GetShowAsync(Guid id)
    {
        var show = await _repository.GetByIdAsync(id); 
        if (show is null) return null;

        return new ShowReadDto
        {
            Id = show.Id,
            HallId = show.HallId,
            MovieId = show.MovieId,
            StartTime = show.StartTime,
            Price = show.Price,
            MovieTitle = show.Movie?.Title ?? "",
            HallName = show.Hall?.Name ?? ""
        };
    }
    public async Task<List<ShowReadDto>> GetShowsByMovieAsync(Guid movieId)
    {
        var shows = await _repository.GetByMovieIdAsync(movieId);

        return shows.Select(s => new ShowReadDto
        {
            Id = s.Id,
            MovieId = s.MovieId,
            HallId = s.HallId,
            StartTime = s.StartTime,
            Price = s.Price,
            MovieTitle = s.Movie.Title,
            HallName = s.Hall.Name
        }).ToList();
    }

    public async Task<Guid> CreateShowAsync(ShowCreateDto dto)
    {
        var show = new Show
        {
            Id = Guid.NewGuid(),
            HallId = dto.HallId,
            MovieId = dto.MovieId,
            StartTime = dto.StartTime,
            Price = dto.Price
        };
        await _repository.AddAsync(show);
        return show.Id;
    }

}
