using Domain.Entities;
using Application.Dtos.Bookings;

namespace Application.Extensions
{
    public static class BookingExtensions
    {
        public static BookingReadDto ToReadDto(this Booking booking)
        {
            return new BookingReadDto
            {
                Id = booking.Id,
                ShowId = booking.ShowId,
                NumberOfTickets = booking.NumberOfTickets,
                BookedAt = booking.BookedAt,
                MovieTitle = booking.Show.Movie.Title,
                ShowTime = booking.Show.StartTime,
                CustomerName = booking.Customer?.Name ?? "Ukendt",
                HallName = booking.Show.Hall.Name,
                CinemaName = booking.Show.Hall.Cinema.Name
            };
        }
    }
}
