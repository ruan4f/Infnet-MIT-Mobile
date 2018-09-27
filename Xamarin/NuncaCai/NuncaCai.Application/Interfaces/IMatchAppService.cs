using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NuncaCai.Application.Interfaces
{
    public interface IMatchAppService
    {
        Task AddSync(Guid id, Guid player1Id, Guid player2Id, Guid winnerId);
        Task AddSync(Match match);
        Task UpdateSync(Match match);
        IEnumerable<Match> GetAll();
        Task<Match> GetByIdSync(Guid id);
        void RemoveAll();
    }
}
