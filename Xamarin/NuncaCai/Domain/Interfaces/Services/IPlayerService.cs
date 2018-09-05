using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IPlayerService
    {
        void Add(Player player);
        IEnumerable<Player> GetAll();
    }
}
