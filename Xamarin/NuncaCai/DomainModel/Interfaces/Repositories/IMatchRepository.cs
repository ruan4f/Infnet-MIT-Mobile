using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Interfaces.Repositories
{
    public interface IMatchRepository
    {
        void Add(Match match);
        void Update(Match match);
        IEnumerable<Match> GetAll();
        Match GetById(Guid id);
    }
}
