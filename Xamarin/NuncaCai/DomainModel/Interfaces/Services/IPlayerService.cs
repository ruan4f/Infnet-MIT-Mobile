using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Interfaces.Services
{
    public interface IPlayerService
    {

        void Add(Player player);

        void Update(Player player);

        IEnumerable<Player> GetAll();

        Player GetById(Guid id);

    }
}
