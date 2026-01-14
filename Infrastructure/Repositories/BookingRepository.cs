using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class BookingRepository : IBookingRepository
{
    private readonly AppDbContext _context;

    public BookingRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<List<Booking>> GetAllAsync()
        => _context.Bookings.AsNoTracking().ToListAsync();

    public Task<Booking?> GetByIdAsync(Guid id)
        => _context.Bookings.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);

    public Task<List<Booking>> GetAllIncludingShowAndMovieAsync()
    {
        return _context.Bookings
            .Include(b => b.Show)
                .ThenInclude(s => s.Movie)
            .AsNoTracking()
            .ToListAsync();
    }

    public Task<Booking?> GetByIdIncludingShowAndMovieAsync(Guid id)
    {
        return _context.Bookings
            .Include(b => b.Show)
                .ThenInclude(s => s.Movie)
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<List<Booking>> GetAllIncludingShowAndMovieAndCustomerAsync()
    {
        return await _context.Bookings
            .Include(b => b.Show)
                .ThenInclude(s => s.Movie)
            .Include(b => b.Customer)
            .ToListAsync();
    }


    public async Task AddAsync(Booking booking)
    {
        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Booking booking)
    {
        _context.Bookings.Update(booking);
        await _context.SaveChangesAsync();
    }
}
