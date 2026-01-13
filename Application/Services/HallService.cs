using Application.Dtos.Hall;
using Application.Interfaces;
using Domain.Entities;

public class HallService : IHallService
{
    private readonly IHallRepository _repository;

    public HallService(IHallRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<HallReadDto>> GetHallsAsync()
    {
        var halls = await _repository.GetAllAsync();
        return halls.Select(h => new HallReadDto
        {
            Id = h.Id,
            Name = h.Name,
            TotalSeats = h.TotalSeats,
            CinemaId = h.CinemaId
        }).ToList();
    }

    public async Task<HallReadDto?> GetHallAsync(Guid id)
    {
        var hall = await _repository.GetByIdAsync(id);
        if (hall is null) return null;

        return new HallReadDto
        {
            Id = hall.Id,
            Name = hall.Name,
            TotalSeats = hall.TotalSeats,
            CinemaId = hall.CinemaId
        };
    }

    public async Task<Guid> CreateHallAsync(HallCreateDto dto)
    {
        var hall = new Hall
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            TotalSeats = dto.TotalSeats,
            CinemaId = dto.CinemaId
        };
        await _repository.AddAsync(hall);
        return hall.Id;
    }

}
