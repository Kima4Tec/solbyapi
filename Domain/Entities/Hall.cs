using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Hall
    {
        public Guid Id { get; set; }
        public Guid CinemaId { get; set; }
        public string Name { get; set; } = null!;
        public int TotalSeats { get; set; }

        public Cinema Cinema { get; set; } = null!;
        public ICollection<Show> Shows { get; set; } = new List<Show>();
    }

}
