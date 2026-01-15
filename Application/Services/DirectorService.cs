
using Application.Dtos.Director;
using Application.Interfaces;
using Domain.Entities;
namespace Application.Services
{

    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _repository;

        public DirectorService(IDirectorRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DirectorDto>> GetAllDirectorsAsync()
        {
            var directors = await _repository.GetAllAsync();
            return directors.Select(d => new DirectorDto
            {
                Id = d.Id,
                Name = d.Name
            }).ToList();
        }
        public async Task<Guid> CreateDirectorAsync(DirectorCreateDto dto)
        {
            var director = new Director
            {
                Id = Guid.NewGuid(),
                Name = dto.Name
            };

            await _repository.AddAsync(director);
            return director.Id;
        }

    }

}
