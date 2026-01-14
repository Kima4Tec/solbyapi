using Application.Dtos.Movies;
using Application.Dtos.Director;
using Application.Interfaces;
using Domain.Entities;


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
            Description = m.Description,
            Directors = m.MovieDirectors
                         .Select(md => new DirectorDto
                         {
                             Id = md.DirectorId,
                             Name = md.Director.Name
                         })
                         .ToList()
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
            Description = movie.Description,
            Directors = movie.MovieDirectors
                         .Select(md => new DirectorDto
                         {
                             Id = md.DirectorId,
                             Name = md.Director.Name
                         })
                         .ToList()
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

        if (dto.DirectorIds.Any())
        {
            var directors = await _repository.GetDirectorsByIdsAsync(dto.DirectorIds);

            foreach (var director in directors)
            {
                movie.MovieDirectors.Add(new MovieDirector
                {
                    MovieId = movie.Id,
                    DirectorId = director.Id
                });
            }
        }

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


        if (dto.DirectorIds != null)
        {

            movie.MovieDirectors.Clear();

            var directors = await _repository.GetDirectorsByIdsAsync(dto.DirectorIds);
            foreach (var director in directors)
            {
                movie.MovieDirectors.Add(new MovieDirector
                {
                    MovieId = movie.Id,
                    DirectorId = director.Id
                });
            }
        }

        await _repository.UpdateAsync(movie);
        return true;
    }
}
