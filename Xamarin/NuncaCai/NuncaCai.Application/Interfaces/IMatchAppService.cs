using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NuncaCai.Application.Interfaces
{
    public interface IMatchAppService
    {
        Task AddSync(Match match);
        Task UpdateSync(Match match);
        IEnumerable<Match> GetAll();
        Task<Match> GetByIdSync(Guid id);
    }
}
