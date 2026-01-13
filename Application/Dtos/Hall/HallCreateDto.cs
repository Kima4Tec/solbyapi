using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Hall
{
    public class HallCreateDto
    {
        public Guid CinemaId { get; set; }
        public string Name { get; set; } = null!;
        public int TotalSeats { get; set; }
    }

}
