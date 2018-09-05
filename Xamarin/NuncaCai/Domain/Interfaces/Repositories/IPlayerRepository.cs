using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IPlayerRepository
    {
        void Add(Player player);

        IEnumerable<Player> GetAll();
    }
}
