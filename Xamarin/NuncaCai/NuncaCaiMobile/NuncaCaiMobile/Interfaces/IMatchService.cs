using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NuncaCaiMobile.Interfaces
{
    public interface IMatchService
    {
        void Add(Match match);

        IEnumerable<Match> GetAll();
    }
}
