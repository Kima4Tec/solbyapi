namespace Domain.Entities
{
    public class Show
    {
        public Guid Id { get; set; }

        public Guid MovieId { get; set; }
        public Guid HallId { get; set; }

        public DateTime StartTime { get; set; }
        public decimal Price { get; set; }

        public Movie Movie { get; set; } = null!;
        public Hall Hall { get; set; } = null!;

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }

}
