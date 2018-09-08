using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainModel.Interfaces.Repositories
{
    public interface IMatchRepository
    {
        Task AddSync(Match match);
        Task UpdateSync(Match match);
        IEnumerable<Match> GetAll();
        Task<Match> GetByIdSync(Guid id);
    }
}
