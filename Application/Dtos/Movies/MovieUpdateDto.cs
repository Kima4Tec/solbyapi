using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Movies
{
    public class MovieUpdateDto
    {
        public string Title { get; set; } = null!;
        public int DurationMinutes { get; set; }
        public int AgeLimit { get; set; }
        public string? Description { get; set; }
    }

}
