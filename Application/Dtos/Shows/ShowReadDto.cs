using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Shows
{
    public class ShowReadDto
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Guid HallId { get; set; }

        public DateTime StartTime { get; set; }
        public decimal Price { get; set; }

        public string MovieTitle { get; set; } = null!;
        public string HallName { get; set; } = null!;
    }

}
