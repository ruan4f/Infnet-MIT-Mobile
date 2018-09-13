using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NuncaCaiMobile.Interfaces
{
    public interface IPlayerService
    {


        void Add(Player player);

        IEnumerable<Player> GetAll();
    }
}
