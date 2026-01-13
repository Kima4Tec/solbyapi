using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Bookings
{
    public class BookingCreateDto
    {
        public Guid ShowId { get; set; }
        public Guid CustomerId { get; set; }
        public int NumberOfTickets { get; set; }
    }

}
