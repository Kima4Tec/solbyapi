using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Bookings
{
    public class BookingReadDto
    {
        public Guid Id { get; set; }
        public Guid ShowId { get; set; }
        public int NumberOfTickets { get; set; }
        public DateTime BookedAt { get; set; }

        public string MovieTitle { get; set; }
        public DateTime ShowTime { get; set; }

        public string CustomerName { get; set; }

        public string CinemaName { get; set; } = null!;
        public string HallName { get; set; } = null!;
    }


}
