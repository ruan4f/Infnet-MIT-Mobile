using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NuncaCai.Application.Interfaces
{
    public interface IMatchAppService
    {
        void Add(Match match);
        void Update(Match match);
        IEnumerable<Match> GetAll();
        Match GetById(Guid id);
    }
}
