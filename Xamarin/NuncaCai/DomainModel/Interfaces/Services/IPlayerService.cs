using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Interfaces.Services
{
    public interface IPlayerService
    {

        Task AddSync(Player player);

        void Update(Player player);

        IEnumerable<Player> GetAll();

        Task<Player> GetByIdSync(Guid id);

    }
}
