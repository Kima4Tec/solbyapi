using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Bookings
{
    public class BookingCreateDto
    {
        public Guid ShowId { get; set; }
        public Guid CustomerId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Antal billetter skal være mindst 1.")]
        public int NumberOfTickets
        {
            get; set;
        }
    }

}
