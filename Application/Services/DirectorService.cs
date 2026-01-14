
using Application.Dtos.Director;
using Application.Interfaces;
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
    }

}
