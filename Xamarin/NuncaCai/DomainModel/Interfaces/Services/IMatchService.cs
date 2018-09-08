using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Interfaces.Services
{
    public interface IMatchService
    {
        void Add(Match match);
        void Update(Match match);
        IEnumerable<Match> GetAll();
    }
}
