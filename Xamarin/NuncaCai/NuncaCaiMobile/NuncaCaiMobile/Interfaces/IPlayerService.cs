using NuncaCaiMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NuncaCaiMobile.Interfaces
{
    public interface IPlayerService
    {
        Task AddSync(Player player);

        void Update(Player player);

        IEnumerable<Player> GetAll();
    }
}
