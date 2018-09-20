using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NuncaCai.Application.Interfaces
{
    public interface IMatchAppService
    {
        Task<Match> AddSync(Guid id, Guid player1Id, Guid player2Id, Guid winnerId);
        
        IEnumerable<Match> GetAll();
        Task<Match> GetByIdSync(Guid id);
    }
}
