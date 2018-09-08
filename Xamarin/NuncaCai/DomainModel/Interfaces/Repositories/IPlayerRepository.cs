using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Interfaces.Repositories
{
    public interface IPlayerRepository
    {
        void Add(Player player);

        void Update(Player player);

        IEnumerable<Player> GetAll();

        Player GetById(Guid id);
    }
}
