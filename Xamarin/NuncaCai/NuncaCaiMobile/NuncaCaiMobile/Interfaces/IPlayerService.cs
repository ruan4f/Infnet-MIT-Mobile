using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NuncaCaiMobile.Interfaces
{
    public interface IPlayerService
    {

        IEnumerable<Player> GetAll();
    }
}
