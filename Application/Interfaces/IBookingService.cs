using Application.Dtos.Bookings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IBookingService
{
    Task<List<BookingReadDto>> GetBookingsAsync();
    Task<BookingReadDto?> GetBookingAsync(Guid id);
    Task<Guid> CreateBookingAsync(BookingCreateDto dto);
    Task<bool> UpdateBookingAsync(Guid id, BookingCreateDto dto);
}
