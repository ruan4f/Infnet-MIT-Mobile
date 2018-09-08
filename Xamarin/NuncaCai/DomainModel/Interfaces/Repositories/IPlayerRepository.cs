using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Interfaces.Repositories
{
    public interface IPlayerRepository
    {
        void Add(Player match);
        void Update(Player match);
        Player GetById(Guid id);
        IEnumerable<Player> GetAll();
    }
}
