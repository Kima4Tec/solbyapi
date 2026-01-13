using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public class Cinema
    {
        public Guid Id { get; set; }

        //null er ikke okay her, men det er den heller ikke ved runtime
        public string Name { get; set; } = null!;

        //null er okay her
        public string? City { get; set; }
    }
}
