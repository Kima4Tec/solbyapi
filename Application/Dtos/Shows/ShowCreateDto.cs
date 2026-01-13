using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Shows
{
    public class ShowCreateDto
    {
        public Guid MovieId { get; set; }
        public Guid HallId { get; set; }
        public DateTime StartTime { get; set; }
        public decimal Price { get; set; }
    }

}
