using NuncaCaiMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NuncaCaiMobile.Interfaces
{
    public interface IMatchRepository
    {
        void Add(Match match);
        void Update(Match match);
        IEnumerable<Match> GetAll();
    }
}
