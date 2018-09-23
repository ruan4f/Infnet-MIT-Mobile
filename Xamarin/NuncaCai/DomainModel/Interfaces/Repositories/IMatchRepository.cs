using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainModel.Interfaces.Repositories
{
    public interface IMatchRepository
    {
        Task AddSync(Guid id, Guid player1Id, Guid player2Id, Guid winnerId, DateTime date);
        Task UpdateSync(Match match);
        IEnumerable<Match> GetAll();
        Task<Match> GetByIdSync(Guid id);
    }
}
