using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Cinema> Cinemas => Set<Cinema>();
        public DbSet<Hall> Halls => Set<Hall>();
        public DbSet<Show> Shows => Set<Show>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Booking> Bookings => Set<Booking>();

    }
}
