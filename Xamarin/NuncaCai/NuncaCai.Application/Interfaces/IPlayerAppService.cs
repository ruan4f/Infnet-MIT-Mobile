using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NuncaCai.Application.Interfaces
{
    public interface IPlayerAppService
    {
        Task AddSync(Player player);

        Task UpdateSync(Player player);

        Task AddPointSync(Guid id);

        IEnumerable<Player> GetAll();

        Task<Player> GetByIdSync(Guid id);

        void RemoveAll();
    }
}
