using Application.Dtos.Movies;
using Application.Interfaces;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _repository;

    public MovieService(IMovieRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<MovieReadDto>> GetMoviesAsync()
    {
        var movies = await _repository.GetAllAsync();

        return movies.Select(m => new MovieReadDto
        {
            Id = m.Id,
            Title = m.Title,
            DurationMinutes = m.DurationMinutes,
            AgeLimit = m.AgeLimit,
            Description = m.Description
        }).ToList();
    }

    public async Task<MovieReadDto?> GetMovieAsync(Guid id)
    {
        var movie = await _repository.GetByIdAsync(id);
        if (movie is null) return null;

        return new MovieReadDto
        {
            Id = movie.Id,
            Title = movie.Title,
            DurationMinutes = movie.DurationMinutes,
            AgeLimit = movie.AgeLimit,
            Description = movie.Description
        };
    }

    public async Task<Guid> CreateMovieAsync(MovieCreateDto dto)
    {
        var movie = new Movie
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            DurationMinutes = dto.DurationMinutes,
            AgeLimit = dto.AgeLimit,
            Description = dto.Description
        };

        await _repository.AddAsync(movie);
        return movie.Id;
    }

    public async Task<bool> UpdateMovieAsync(Guid id, MovieUpdateDto dto)
    {
        var movie = await _repository.GetByIdAsync(id);
        if (movie is null) return false;

        movie.Title = dto.Title;
        movie.DurationMinutes = dto.DurationMinutes;
        movie.AgeLimit = dto.AgeLimit;
        movie.Description = dto.Description;

        await _repository.UpdateAsync(movie);
        return true;
    }
}
