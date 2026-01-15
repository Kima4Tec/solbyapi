using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IBookingRepository
{
    Task<List<Booking>> GetAllAsync();
    Task<Booking?> GetByIdAsync(Guid id);

    // Metoder der inkluderer Show og Movie til DTO
    Task<List<Booking>> GetAllIncludingShowAndMovieAsync();
    Task<Booking?> GetByIdIncludingShowAndMovieAsync(Guid id);
    Task<List<Booking>> GetAllIncludingShowAndMovieAndCustomerAsync();
    Task<List<Booking>> GetAllIncludingShowMovieHallCinemaAsync();
    Task AddAsync(Booking booking);
    Task UpdateAsync(Booking booking);
}
