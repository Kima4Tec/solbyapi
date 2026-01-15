using Application.Dtos.Bookings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _repository;

    public BookingService(IBookingRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<BookingReadDto>> GetAllBookingsAsync()
    {
        var bookings = await _repository.GetAllIncludingShowMovieHallCinemaAsync();

        return bookings.Select(b => new BookingReadDto
        {
            Id = b.Id,
            ShowId = b.ShowId,
            NumberOfTickets = b.NumberOfTickets,
            BookedAt = b.BookedAt,
            MovieTitle = b.Show.Movie.Title,
            ShowTime = b.Show.StartTime,
            CustomerName = b.Customer?.Name ?? "Ukendt",
            HallName = b.Show.Hall.Name,
            CinemaName = b.Show.Hall.Cinema.Name
        }).ToList();
    }


    public async Task<List<BookingReadDto>> GetBookingsAsync()
    {
        var bookings = await _repository.GetAllIncludingShowAndMovieAndCustomerAsync();

        return bookings.Select(b => new BookingReadDto
        {
            Id = b.Id,
            ShowId = b.ShowId,
            NumberOfTickets = b.NumberOfTickets,
            BookedAt = b.BookedAt,
            MovieTitle = b.Show.Movie.Title,
            ShowTime = b.Show.StartTime,
            CustomerName = b.Customer?.Name ?? "Ukendt",
        }).ToList();
    }


    public async Task<BookingReadDto?> GetBookingAsync(Guid id)
    {
        var booking = await _repository.GetByIdIncludingShowAndMovieAsync(id);
        if (booking is null) return null;

        return new BookingReadDto
        {
            Id = booking.Id,
            ShowId = booking.ShowId,
            NumberOfTickets = booking.NumberOfTickets,
            BookedAt = booking.BookedAt,
            MovieTitle = booking.Show.Movie.Title,
            ShowTime = booking.Show.StartTime,
            CustomerName = booking.Customer.Name
        };
    }

    public async Task<Guid> CreateBookingAsync(BookingCreateDto dto)
    {
        var booking = new Booking
        {
            Id = Guid.NewGuid(),
            ShowId = dto.ShowId,
            CustomerId = dto.CustomerId,
            NumberOfTickets = dto.NumberOfTickets,
            BookedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(booking);
        return booking.Id;
    }

    public async Task<bool> UpdateBookingAsync(Guid id, BookingCreateDto dto)
    {
        var booking = await _repository.GetByIdAsync(id);
        if (booking is null) return false;

        booking.ShowId = dto.ShowId;
        booking.CustomerId = dto.CustomerId;
        booking.NumberOfTickets = dto.NumberOfTickets;

        await _repository.UpdateAsync(booking);
        return true;
    }
}
