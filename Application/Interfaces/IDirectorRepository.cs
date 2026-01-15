using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDirectorRepository
    {
        Task<List<Director>> GetAllAsync();
        Task AddAsync(Director director);
    }
}
