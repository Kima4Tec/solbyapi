using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MovieDirector
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; } = null!;

        public Guid DirectorId { get; set; }
        public Director Director { get; set; } = null!;
    }

}
