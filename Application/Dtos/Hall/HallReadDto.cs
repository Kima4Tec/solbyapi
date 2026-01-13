using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Hall
{
    public class HallReadDto
    {
        public Guid Id { get; set; }
        public Guid CinemaId { get; set; }

        public string Name { get; set; } = null!;
        public int TotalSeats { get; set; }

        public string CinemaName { get; set; } = null!;
    }

}
