

namespace Application.Services
{
    using Application.Dtos.Cinemas;
    using Application.Interfaces;
    using Domain.Entities;

    public class CinemaService : ICinemaService
    {
        private readonly ICinemaRepository _repository;

        public CinemaService(ICinemaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CinemaReadDto>> GetCinemasAsync()
        {
            var cinemas = await _repository.GetAllAsync();
            return cinemas.Select(c => new CinemaReadDto
            {
                Id = c.Id,
                Name = c.Name,
                City = c.City
            }).ToList();
        }

        public async Task<CinemaReadDto?> GetCinemaAsync(Guid id)
        {
            var cinema = await _repository.GetByIdAsync(id);
            if (cinema is null) return null;

            return new CinemaReadDto
            {
                Id = cinema.Id,
                Name = cinema.Name,
                City = cinema.City
            };
        }

        public async Task<Guid> CreateCinemaAsync(CinemaCreateDto dto)
        {
            var cinema = new Cinema
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                City = dto.City
            };
            await _repository.AddAsync(cinema);
            return cinema.Id;
        }

    }

}
