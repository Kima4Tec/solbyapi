using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Booking
    {
        public Guid Id { get; set; }

        public Guid ShowId { get; set; }
        public Guid CustomerId { get; set; }

        public int NumberOfTickets { get; set; }
        public DateTime BookedAt { get; set; }

        public Show Show { get; set; } = null!;
        public Customer Customer { get; set; } = null!;
    }

}
