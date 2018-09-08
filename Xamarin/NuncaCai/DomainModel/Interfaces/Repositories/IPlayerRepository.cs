using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Interfaces.Repositories
{
    public interface IPlayerRepository
    {
        Task AddSync(Player match);
        Task UpdateSync(Player match);
        Task<Player> GetByIdSync(Guid id);
        IEnumerable<Player> GetAll();
    }
}
