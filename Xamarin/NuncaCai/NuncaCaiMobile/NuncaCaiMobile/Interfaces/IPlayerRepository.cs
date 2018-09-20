using NuncaCaiMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NuncaCaiMobile.Interfaces
{
    public interface IPlayerRepository
    {
        void Add(Player player);
        void Update(Player player);
        IEnumerable<Player> GetAll();
    }
}
